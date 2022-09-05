// 曲线

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Scaling : MonoBehaviour
    {
        public float scale;
        public AnimationCurve curve;

        private void Start()
        {
            scale = 5f;
        }

        private void Update()
        {
            scale = curve.Evaluate(Time.time / 2f) * 2f;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}