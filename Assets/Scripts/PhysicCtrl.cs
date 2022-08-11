using System;
using UnityEngine;


namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))] // 必须有刚体组件
    public class PhysicCtrl : MonoBehaviour
    {
        public Rigidbody rb;
        

        private void Awake()
        {
            rb = gameObject.GetComponent("Rigidbody") as Rigidbody;
            // rb = gameObject.GetComponent<Rigidbody>();
        }

        public void addImpulse()
        {
            rb.AddForce(0,0,-10, ForceMode.Impulse);
        }
    }
}