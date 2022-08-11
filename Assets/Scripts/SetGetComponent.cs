// 获取组件的方法

using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SetGetComponent : MonoBehaviour
    {
        public PhysicCtrl[] PSCs;

        private void Awake()
        {
            PSCs = new PhysicCtrl[3];
            
        }

        private void OnEnable()
        {
            //GetComponentInChildren，会优先判断物体自身是否有目标组件，若有直接返回该组件，不便利子物体；若物体自身没有目标组件，遍历子物体，按照子物体顺序查找（比如：先判断第一个子物体，若没有获取到目标组件，再遍历第一个子物体的子物体(目标物体孙物体)，然后再判断目标物体的第二个子物体，以此递归查找）。
            // 延伸：GetComponentsInChildren，会获取包含物体自身、节点下所有子物体、孙物体的目标组件，也是递归：
            // PSCs[0] = gameObject.GetComponentsInParent<PhysicCtrl>()[1];
            PSCs[1] = gameObject.GetComponentsInChildren<PhysicCtrl>()[1];
            PSCs[0] = transform.parent.gameObject.GetComponent<PhysicCtrl>();
            PSCs[2] = gameObject.GetComponent<PhysicCtrl>();
            // PSCs[2] = GameObject.Find("Cube (2)").GetComponent<PhysicCtrl>();
        }

        private void Start()
        {
            foreach (PhysicCtrl psc in PSCs)
            {
                psc.addImpulse();
            }
        }
    }
}