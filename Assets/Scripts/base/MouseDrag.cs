// 鼠标拖拽

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MouseDrag : MonoBehaviour
    {
        public Camera mCamera = null;
        public float depth = 10f;
        private void OnMouseEnter()
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        private void OnMouseExit()
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        private void OnMouseOver()
        {
            transform.Rotate(Vector3.up, 45f * Time.deltaTime);
        }

        private void OnMouseDrag()
        {
            // MoveObject();
            MoveObjectFixedDepth();
        }

        private void MoveObject()
        {
            Ray r = mCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log("P"+Input.mousePosition.ToString());
            RaycastHit hit;
            if (Physics.Raycast(r, out hit, 2000f, 1))
            {
                transform.position = new Vector3(hit.point.x, hit.point.y+0.5f, hit.point.z);
                Debug.DrawLine(r.origin, hit.point);
            }
        }

        private void MoveObjectFixedDepth()
        {
            Vector3 mouseScreen = Input.mousePosition;
            mouseScreen.z = depth;
            Vector3 mouseWorld = mCamera.ScreenToWorldPoint(mouseScreen);
            transform.position = mouseWorld;
        }
    }
}