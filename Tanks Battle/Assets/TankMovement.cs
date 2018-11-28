using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TankMovement : MonoBehaviour
    {
        new Rigidbody2D rigidbody;

        [SerializeField] InputData input = null;
        [SerializeField] float force = 100;

        private void OnValidate() {
            if (!input) input = GetComponent<InputData>();
        }
        private void Awake() {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            rigidbody.AddForce(Vector2.right * (force * input.Horizontal));
        }
    }

}