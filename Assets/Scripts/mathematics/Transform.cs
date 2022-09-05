// 变换信息

using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace DefaultNamespace
{
    public class Transform : MonoBehaviour
    {
        public GameObject target;
        private void Start()
        {
            Debug.Log("World Euler Angle X "+ transform.rotation.x);
            Debug.Log("World Euler Angle Y "+ transform.rotation.y);
            Debug.Log("World Euler Angle Z "+ transform.rotation.z);
            Debug.Log("Local Euler Angle X "+ transform.localEulerAngles.x);
            Debug.Log("Local Euler Angle y "+ transform.localEulerAngles.y);
            Debug.Log("Local Euler Angle Z "+ transform.localEulerAngles.z);
            Debug.Log("World Position X "+ transform.position.x);
            Debug.Log("World Position Y "+ transform.position.y);
            Debug.Log("World Position Z "+ transform.position.z);
            Debug.Log("Local Position X "+ transform.localPosition.x);
            Debug.Log("Local Position y "+ transform.localPosition.y);
            Debug.Log("Local Position Z "+ transform.localPosition.z);
            // Debug.Log("World Scale X "+ transform.localScale.x);
            // Debug.Log("World Scale Y "+ transform.rotation.y);
            // Debug.Log("World Scale Z "+ transform.rotation.z);
            Debug.Log("Local Scale X "+ transform.localScale.x);
            Debug.Log("Local Scale y "+ transform.localScale.y);
            Debug.Log("Local Scale Z "+ transform.localScale.z);
        }

        private void Update()  
        {
            // transform.Rotate(5f * Time.deltaTime, 0, 0, Space.Self);
            // transform.Rotate(new Vector3(1,1,1), 45*Time.deltaTime, Space.World );
            // Vector3 top = new Vector3(transform.position.x + 5f, transform.position.y + 5f, transform.position.z + 5f);
            // Vector3 button = new Vector3(transform.position.x - 5f, transform.position.y - 5f, transform.position.z - 5f);
            // Debug.DrawLine(top, button, Color.blue);
            // transform.RotateAround(target.transform.position, Vector3.up, 45f*Time.deltaTime);
            transform.LookAt(target.transform.position);
        }
    }
}