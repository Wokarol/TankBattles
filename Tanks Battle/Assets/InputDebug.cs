using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wokarol.DebugUtils
{
    public class InputDebug : MonoBehaviour
    {
        [SerializeField] Image horizontalFill = null;
        [SerializeField] Image verticalFill = null;
        [SerializeField] GameObject shootImage = null;

        [Space]
        [SerializeField] InputData input;

        private void Update() {
            shootImage.SetActive(input.Shoot);
            horizontalFill.fillAmount = (input.Horizontal + 1) * 0.5f;
            verticalFill.fillAmount = (input.Aim + 1) * 0.5f;
        }
    } 
}
