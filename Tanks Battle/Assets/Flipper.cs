using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Flipper : MonoBehaviour
    {
        new Rigidbody2D rigidbody;
        [SerializeField] float force = 3000;
        [SerializeField] float rotatingSpeed = 720;
        [SerializeField] bool active;
        bool Active {
            get => active;
            set {
                if (active && !value) {
                    rigidbody.angularDrag -= 100;
                } else if(!active && value){
                    rigidbody.angularDrag += 100;
                }
                active = value;

            }
        }

        [SerializeField] MinMax normalAngles = new MinMax(-150, 150);
        [SerializeField] float upsideDownTime;
        float upsideDownTimer;

        private void Awake() {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Update() {
            if (normalAngles.IsOutside(rigidbody.rotation)){
                upsideDownTimer += Time.deltaTime;
            } else {
                upsideDownTimer = 0;
            }


            if (Input.GetKeyDown(KeyCode.F4)) {
                rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                Active = true;
            }
            if (Active) {
                if (Mathf.Abs(rigidbody.rotation) < 5) {
                    Active = false;
                } else
                    rigidbody.rotation = Mathf.MoveTowardsAngle(rigidbody.rotation, 0, rotatingSpeed * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            Active = false;
        }
    }
}
