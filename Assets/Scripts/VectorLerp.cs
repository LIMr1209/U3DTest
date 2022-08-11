using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class VectorLerp : MonoBehaviour
    {
        public AnimationCurve curve;
        public Vector3 distance = new Vector3(10, 0, 0);
        public float x;
        private void OnGUI()
        {
            if (GUILayout.RepeatButton("moveTowards"))
            {
                // 匀速移动 可以到达终点
                transform.position = Vector3.MoveTowards(transform.position, distance, 0.1f);
            }
            if (GUILayout.RepeatButton("lerp"))
            {
                // 先快后慢 不可以到达终点 比例固定
                transform.position = Vector3.Lerp(transform.position, distance, 0.1f);
            }
            if (GUILayout.RepeatButton("lerpCurve"))
            {
                x += Time.deltaTime/4; // 4 秒内
                // 自然运动 可以到达终点  比例随曲线变化
                transform.position = Vector3.Lerp(transform.position, distance, curve.Evaluate(x));
            }
        }
    }
}