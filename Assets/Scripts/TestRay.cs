using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestRay : MonoBehaviour
    {
        public GameObject parachute;
        public float rayDistance = 4;

        private bool deployed = false;

        private void Update()
        {
            Ray testRay = new Ray(transform.position, Vector3.down);
            RaycastHit hitInfomation;
            if (!deployed)
            {
                if (Physics.Raycast(testRay, out hitInfomation, rayDistance))
                {
                    if (hitInfomation.collider.tag == "test")
                    {
                        Deploy();
                    }
                }
            }
        }

        void Deploy()
        {
            deployed = true;
            parachute.GetComponent<Rigidbody>().drag = 8f;
            parachute.GetComponent<Animation>().Play("parachute_close");
        }

        private void OnCollisionEnter(Collision other)
        {
            parachute.GetComponent<Animation>().Play("parachute_close");
        }
    }
}