using UnityEngine;

namespace Wokarol
{
    [System.Serializable]
    public class MinMax
    {
        [SerializeField] float min;
        [SerializeField] float max;

        public MinMax(float min, float max) {
            this.min = min;
            this.max = max;
        }

        public float Min { get => min; set => min = value; }
        public float Max { get => max; set => max = value; }

        public float Clamp(float value) {
            return Mathf.Min(max, Mathf.Max(min, value));
        }

        public bool IsInside(float value) {
            return value <= max && value >= min;
        }

        public bool IsOutside(float value) {
            return value >= max || value <= min;
        }
    }
}