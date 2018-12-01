using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    public class PlayerInput : InputData
    {
        private void Update() {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Aim = Input.GetAxisRaw("Vertical");
            Shoot = Input.GetKey(KeyCode.Space);
        }
    } 
}
