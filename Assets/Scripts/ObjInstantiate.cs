// 刚体添加力的作用 add force

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjInstantiate : MonoBehaviour
    {
        // public GameObject obj;
        public Rigidbody rb;
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 生成组件得话 也会生成物体
                // GameObject ob = Instantiate(obj,new Vector3(0,10,0), Quaternion.identity);
                Rigidbody rbo = Instantiate(rb, new Vector3(0, 5, 0), Quaternion.identity);
                rbo.AddForce(new Vector3(0,0,6), ForceMode.Impulse);
            }
        }
    }
}  