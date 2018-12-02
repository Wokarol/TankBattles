using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    public class TankController2D : MonoBehaviour
    {
        [SerializeField] LayerMask groundMask;
        [SerializeField] float maxDistance;

        // Cache
        new Rigidbody2D rigidbody;
        MinMax movementAngles = new MinMax(0, 180);

        private void Awake() {
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.simulated = false;
        }

        private void Update() {

            var underWheelsHit = Physics2D.Raycast(transform.position, -transform.up, 10f, groundMask);
            if (!underWheelsHit.transform || movementAngles.IsOutside(underWheelsHit.normal.GetAngle())) {
                rigidbody.simulated = true;
            } else {
                CalculatePos();
            }

        }

        private void CalculatePos() {
            var hit = Physics2D.Raycast(transform.position + (Vector3.up * 0.3f), Vector2.down, (maxDistance + 0.3f), groundMask);
            if (hit.transform) {
                rigidbody.simulated = false;

                transform.position = hit.point;
                transform.rotation = Quaternion.Euler(0, 0, hit.normal.GetAngle() - 90);
            } else {
                rigidbody.simulated = true;
            }
        }

        public void Move(float speed) {
            if (!rigidbody.simulated) {
                transform.position += transform.right * speed;
            }
        }


        private void OnDrawGizmos() {
            Gizmos.DrawRay(transform.position + (Vector3.up * 0.3f), Vector2.down * (maxDistance + 0.3f));
        }
    }
}
