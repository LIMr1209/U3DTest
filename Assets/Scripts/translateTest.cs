// Translate

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class translateTest : MonoBehaviour
    {
        private void Start()
        {
            Vector3 test = transform.forward;
            Debug.Log(test);
            // 相等
            // transform.Translate(Vector3.forward, Space.Self);
            transform.Translate(transform.forward, Space.World);
        }
    }
}