// 输入管理器

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Keyword : MonoBehaviour
    {
        public bool key;
        public bool keyDown;
        public bool keyUp;

        private void Update()
        {
            // key = Input.GetKey(KeyCode.Space);
            // key = Input.GetKey("Space");
            // key = Input.GetButton("Jump"); // 输入管理器
            key = Input.GetButton("Jump");
            keyDown = Input.GetButtonDown("Jump");
            keyUp = Input.GetButtonUp("Jump");
            if (keyDown)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }

            if (key)
            {
                transform.Rotate(Vector3.up, 45f * Time.deltaTime);
            }

            if (keyUp)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}