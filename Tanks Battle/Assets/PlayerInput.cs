using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    public class PlayerInput : InputData
    {
        private void Update() {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Shoot = Input.GetKey(KeyCode.Space);
        }
    } 
}
