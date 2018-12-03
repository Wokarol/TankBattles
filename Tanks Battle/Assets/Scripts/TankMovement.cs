using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TankMovement : MonoBehaviour
    {
        [SerializeField] InputData input = null;
        [SerializeField] float speed = 100;
        //[SerializeField] float accDccSpeed = 100;
        [SerializeField] HingeJoint2D[] wheels = new HingeJoint2D[0];
        //private float currectSpeed = 0;

        private void OnValidate() {
            if (!input) input = GetComponent<InputData>();
        }

        private void Update() {
            //currectSpeed = Mathf.MoveTowards(currectSpeed, input.Horizontal * speed, accDccSpeed);
            //ApplySpeed(currectSpeed);
            ApplySpeed(input.Horizontal * speed);
        }

        private void ApplySpeed(float speed) {
            for (int i = 0; i < wheels.Length; i++) {
                var motor = wheels[i].motor;
                motor.motorSpeed = speed;
                wheels[i].motor = motor;
            }
        }
    }
}