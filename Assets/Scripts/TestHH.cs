using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestHH : MonoBehaviour
    {
        public Vector3 point;
        public Vector3 origin;
        private void Start()
        {
            point = transform.TransformDirection(new Vector3(10, 0, 0));
            origin = transform.InverseTransformDirection(point);
            Debug.Log(origin);
        }

        private void Update()
        {
            Debug.DrawLine(transform.position, transform.position+point);
        }
    }
}