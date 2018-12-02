using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    public class TankController2D : MonoBehaviour
    {
        [SerializeField] float baseDistance = 1;
        [SerializeField] float maxDistance = 5;
        [SerializeField] int helpRayCount = 2;
        [SerializeField] float helpRaySpacing = 0.2f;
        [SerializeField] LayerMask groundmask = 0;

        // Caching
        Ray2D[] downRaycasts;
        int centreRaycast;
        new Rigidbody2D rigidbody;

        private void Awake() {
            downRaycasts = new Ray2D[helpRayCount + 1];
            centreRaycast = Mathf.FloorToInt(downRaycasts.Length * .5f);
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.simulated = false;
        }
        private void Update() {
            for (int i = 0; i < downRaycasts.Length; i++) {
                downRaycasts[i].origin = transform.position + transform.right * ((helpRaySpacing * i) - (helpRaySpacing * Mathf.Floor(downRaycasts.Length * 0.5f)));
                downRaycasts[i].direction = -transform.up;
            }


            var hit = Physics2D.Raycast(downRaycasts[centreRaycast].origin, downRaycasts[centreRaycast].direction, maxDistance, groundmask);
            if (hit.transform) {
                rigidbody.simulated = false;
                transform.position = hit.point + (Vector2)transform.up * baseDistance;

                float angleSum = 0;
                angleSum += hit.normal.GetAngle() - 90;

                foreach (var ray in downRaycasts) {
                    hit = Physics2D.Raycast(ray.origin, ray.direction, maxDistance, groundmask);
                    if (hit.transform) {
                        angleSum += hit.normal.GetAngle() - 90;
                    }
                }

                transform.rotation = Quaternion.Euler(0, 0, angleSum / downRaycasts.Length);
            } else {
                rigidbody.simulated = true;
            }

        }

        public void Move(float speed) {
            transform.position += transform.right * speed;
        }

        private void OnDrawGizmos() {
            Gizmos.DrawLine((transform.position - transform.up * baseDistance) + transform.right, (transform.position - transform.up * baseDistance) - transform.right);

            for (int i = 0; i < (helpRayCount + 1); i++) {
                Gizmos.DrawRay(
                    transform.position + transform.right * ((helpRaySpacing * i) - (helpRaySpacing * Mathf.Floor((helpRayCount + 1) * 0.5f)))
                    , -transform.up * maxDistance);
            }
        }
    }
}
