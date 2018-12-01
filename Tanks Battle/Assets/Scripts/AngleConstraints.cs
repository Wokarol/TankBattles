using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AngleConstraints : MonoBehaviour
    {
        new Rigidbody2D rigidbody;
        [SerializeField] MinMax angleLimits = new MinMax(-90, 90);
        private void Awake() {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate() {
            if (angleLimits.IsOutside(rigidbody.rotation)) {
                rigidbody.rotation = angleLimits.Clamp(rigidbody.rotation);
            }
        }
    }
}
