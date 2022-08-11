// 鼠标事件

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class OnMouse : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Debug.Log("MouseDown");
        }
        private void OnMouseUp()
        {
            Debug.Log("MouseUp");
        }
        private void OnMouseOver()
        {
            Debug.Log("MouseOver");
        }
        private void OnMouseEnter()
        {
            Debug.Log("MouseEnter");
        }

        private void OnMouseExit()
        {
            Debug.Log("MouseExit");
        }
        
    }
}