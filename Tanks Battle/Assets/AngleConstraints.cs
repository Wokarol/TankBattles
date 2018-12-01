using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AngleContraints : MonoBehaviour
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

    [System.Serializable]
    internal class MinMax
    {
        [SerializeField] float min;
        [SerializeField] float max;

        public MinMax(float min, float max) {
            this.min = min;
            this.max = max;
        }

        public float Min { get => min; set => min = value; }
        public float Max { get => max; set => max = value; }

        internal float Clamp(float value) {
            return Mathf.Min(max, Mathf.Max(min, value));
        }

        internal bool IsOutside(float value) {
            return value > max || value < max;
        }
    }
}
