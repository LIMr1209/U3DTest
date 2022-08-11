// sendmessage 发送消息

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestMessage : MonoBehaviour
    {
        public GameObject[] cubes;

        private void Start()
        {
            cubes = GameObject.FindGameObjectsWithTag("c1");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // foreach (GameObject cube in cubes)
                // {
                //     cube.SetActive(false);
                // }
                // 第三个参数 是否返回错误
                GameObject.Find("Cubes").BroadcastMessage("hide", false);
            }
        }
    }
}