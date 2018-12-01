using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class BarrelController : MonoBehaviour
    {
        [SerializeField] Transform barrelHolder = null;
        [SerializeField] MinMax barrelAngleConstraints = new MinMax(5, 175);
        [SerializeField] float rotationSpeed = 30;
        [Space]
        [SerializeField] Transform gunPoint = null;
        [SerializeField] PoolSystem.Pool bulletPool;
        [Space]
        [SerializeField] InputData input = null;
        bool shooted = false;

        private void OnValidate() {
            if (!input) input = GetComponent<InputData>();
        }

        private void Update() {
            Vector3 barrelRotation = barrelHolder.localRotation.eulerAngles;
            barrelRotation.z += input.Aim * rotationSpeed * Time.deltaTime;

            if (barrelAngleConstraints.IsOutside(barrelRotation.z)) {
               barrelRotation.z = barrelAngleConstraints.Clamp(barrelRotation.z);
            }

            barrelHolder.localRotation = Quaternion.Euler(barrelRotation);

            if (!input.Shoot) {
                shooted = false;
            }
            if(input.Shoot && !shooted) {

                shooted = true;
                bulletPool.Get(gunPoint.position, gunPoint.rotation);
            }
        }
    } 
}
