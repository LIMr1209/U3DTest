// 第三人称 控制器 位置偏差    

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ThirdCro : MonoBehaviour
    {
        public GameObject target;
        public float forward = 20;
        public float height = 10;
        public float speed = 0.15f;
        
        private void LateUpdate()
        {
            Vector3 v = (-target.transform.forward * forward) + new Vector3(0, height, 0);
            Vector3 pos = target.transform.position + v;
            transform.position = Vector3.Lerp(transform.transform.position, pos, speed);
            transform.LookAt(target.transform);
        }
    }
}