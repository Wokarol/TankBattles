using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    [RequireComponent(typeof(TankController2D))]
    public class TankMover : MonoBehaviour
    {
        [SerializeField] InputData input;

        // Caching
        TankController2D tankController;

        private void OnValidate() {
            if (!input) {
                input = GetComponent<InputData>();
            }
        }
        private void Awake() {
            tankController = GetComponent<TankController2D>();
        }

        private void Update() {
            tankController.Move(input.Horizontal * Time.deltaTime);
        }
    } 
}
