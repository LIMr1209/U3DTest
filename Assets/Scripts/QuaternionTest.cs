// 四元数 测试 坐标系转换

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class QuaternionTest : MonoBehaviour
    {
        public Vector3 vect;

        private void Start()
        {
            vect = transform.position;
        }

        private void Update()
        {
            // 四元数 左乘向量 表示将该向量按照四元数表示的角度旋转 
            // 四元数 相乘表示 在原来的基础上旋转
            Debug.DrawLine(transform.position, vect);
            {
                // vect 向量 根据当前物体的旋转而旋转
                vect = transform.rotation * new Vector3(0, 0, 10);
                // vect 向量 y轴 旋转 30度
                // vect = new Vector3(0, 0, 10);
                vect = Quaternion.Euler(0, 30, 0) * vect;
                // vect 向量移动到当前物体位置
                vect = transform.position + vect;
            }
            
            // 轴角的旋转 
            Quaternion.AngleAxis(30, Vector3.up); // 沿y轴旋转 30 度;
            // z轴注释旋转  Quaternion.LookRotation   transform.up = target.transform.position - transform.position;
            // Quaternion.Lerp() 由快到慢 变速旋转 不可能到达目标 使用 Quaternion.Angle() 判断相差多少度
            // Quaternion.RotateTowards() // 匀速旋转
            
            // x轴注释旋转
            // transform.right = target.transform.position - transform.position;
            // 或者
            // Quaternion dir = Quaternion.FromToRotation(Vector3.right, target.transform.position - transform.position);
            // transform.rotation = dir;
            // 缓慢  使用 lerp
            
            // 本地坐标 转世界坐标 
            // transform.TransformPoint() 转换点 受变换组件 位置旋转缩放的影响
            // transform.TransformDirection()  转换点 受变换组件 旋转的影响
            // transform.TransformVector()  转换点 受变换组件 旋转缩放的影响
            
            
            // 世界坐标  转本地坐标
            // transform.InverseTransformPoint() 转换点 受变换组件 位置旋转缩放的影响   mesh 网格顶点凹陷
            // transform.InverseTransformDirection()  转换点 受变换组件 旋转的影响
            // transform.InverseTransformVector()  转换点 受变换组件 旋转缩放的影响

            // Camera.main.ScreenToWorldPoint(); 屏幕坐标转世界坐标
            // Camera.main.WorldToScreenPoint(); 世界坐标转屏幕坐标
            
            // Camera.main.ViewportToWorldPoint(); 视口坐标转世界坐标
            // Camera.main.WorldToViewportPoint(); 世界坐标转视口坐标
        }
    }
}