// unity 生命周期

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LifeCycle : MonoBehaviour
    {
        private void Start()
        // Awake 之后 update 之前 脚本组件被激活时 调用 一搬用来给 变量赋值
        {   
            Debug.Log("Start");
        }

        private void Awake()
        // 初始化函数 游戏开始时自动调用 脚本组件无论是否激活 都将调用 一般用来创建变量
        {
            Debug.Log("Awake");
        }

        private void Update()
        // 每一帧调用一次  一般用于非物理运动
        {
            // Debug.Log("Update");
            this.transform.position = new Vector3(this.transform.position.x,
                this.transform.position.y + 0.1f * Time.deltaTime,
                this.transform.position.z);
        }

        private void FixedUpdate()
        // 每隔固定时间调用一次  一般用于物理运动
        {
            Debug.Log("FixedUpdate");
        }

        private void LateUpdate()
        // update 之后调用一次
        {
            Debug.Log("LateUpdate");
        }
    }
}