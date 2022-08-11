// 协程程序测试

using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestCoroutine : MonoBehaviour
    {
        private void OnMouseDown()
        {
            StartCoroutine("testMove");
        }

        private void OnMouseUp()
        {
            StopCoroutine("testMove");
            // StopAllCoroutines();
        }

        private IEnumerator testMove()
        {
            
            for(int i=0;i<100;i++)
            {
                transform.Translate(1f,0f,0f);
                yield return new WaitForSeconds(1f);  //等待两秒运行
                // yield return null; // 每一帧挂起
            }

            transform.position = new Vector3(0, 2, 0);
        }
    }
}