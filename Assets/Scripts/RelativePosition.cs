using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class RelativePosition : MonoBehaviour
    {
        public GameObject target;
        public Vector3 relative = new Vector3(2, 4, 8);
        public Vector3 originPosition;
        public Vector3 newPosition;

        private void Start()
        {
            originPosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetKeyDown("b"))
            {
                transform.position += transform.TransformDirection(relative);
                newPosition = transform.position;
                transform.position = originPosition;
                Vector3 test = transform.InverseTransformDirection(newPosition-originPosition);
                Debug.Log(test);
                transform.position = newPosition;

            }
            
        }
    }
}