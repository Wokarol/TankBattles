using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public abstract class GenericVariable<T> : ScriptableObject
    {
        [SerializeField] private T value;
        [SerializeField] private bool isReadonly = false;
        public T Value
        {
            get => value;
            set {
                if (isReadonly) {
                    Debug.LogWarning($"You should not change {name} because it's readonly");
                    return;
                } else {
                    this.value = value;
                }
            }
        }
    }
}