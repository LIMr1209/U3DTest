// 销毁对象

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjDestroy : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 2f);
        }
    }
}