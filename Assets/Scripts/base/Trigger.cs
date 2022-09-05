// 触发器

using System;
using UnityEngine;


namespace DefaultNamespace
{
    public class Trigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        // 当碰撞体进入触发器调用一次
        {
            Debug.Log("OnTriggerEnter");
            // other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x ,2, other.gameObject.transform.position.z);
        }

        private void OnTriggerStay(Collider other)
        // 碰撞体接触触发器时 每一帧调用一次
        {
            Debug.Log("OnTriggerStay");
            other.gameObject.transform.position = new Vector3(0, other.gameObject.transform.position.y + 1f*Time.deltaTime ,0);
        }
        
        private void OnTriggerExit(Collider other)
            // 碰撞体离开触发器调用一次
        {
            Debug.Log("OnTriggerExit");
        }
    }
    // OnCollisionEnter方法被触发要符合以下条件
    // 1 碰撞双方必须是碰撞体 
    // 2 碰撞的主动方必须是刚体，注意我的用词是主动方，而不是被动方 
    // 3 刚体不能勾选IsKinematic 
    // 4 碰撞体不能够勾选IsTigger
    //
    // OnCollisionEnter方法的形参对象指的是碰撞双方中没有携带OnCollisionEnter方法的一方
    //
    // OnTriggerEnter触发条件：
    // 1碰撞双方都必须是碰撞体 
    // 2碰撞双方其中一个碰撞体必须勾选IsTigger选项 
    // 3碰撞双方其中一个必须是刚体 
    // 4刚体的IsKinematic选项可以勾选也可以不勾选
}