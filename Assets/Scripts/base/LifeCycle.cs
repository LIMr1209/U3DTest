// unity 生命周期
using UnityEngine;

namespace DefaultNamespace
{
    public class LifeCycle : MonoBehaviour
    {
        
        // 始终在任何 Start 函数之前并在实例化预制件之后调用此函数。（如果游戏对象在启动期间处于非活动状态，则在激活之后才会调用 Awake。）
        private void Awake()
            // 初始化函数 游戏开始时自动调用 脚本组件无论是否激活 都将调用 一般用来创建变量
        {
            Debug.Log("Awake");
        }

        // （仅在对象处于激活状态时调用）在启用对象后立即调用此函数。在创建 MonoBehaviour 实例时（例如加载关卡或实例化具有脚本组件的游戏对象时）会执行此调用。
        private void OnEnable()
        {
            Debug.Log("OnEnable");
        }

        // 行为被禁用或处于非活动状态时，调用此函数。
        private void OnDisable()
        {
            Debug.Log("OnDisable");
        }

        
        // 对象存在的最后一帧完成所有帧更新之后，调用此函数（可能应 Object.Destroy 要求或在场景关闭时销毁该对象）。
        private void OnDestroy()
        {
            Debug.Log("OnDestroy");
        }
        
        // 在退出应用程序之前在所有游戏对象上调用此函数。在编辑器中，用户停止播放模式时，调用函数。
        private void OnApplicationQuit()
        {
            Debug.Log("OnApplicationQuit");
        }

        private void Start()
        // Awake 之后 update 之前 脚本组件被激活时 调用 一搬用来给 变量赋值  仅当启用脚本实例后，才会在第一次帧更新之前调用 Start。
        {   
            Debug.Log("Start");
        }


        private void Update()
        // 每一帧调用一次  一般用于非物理运动
        {
            Debug.Log("Update");
        }

        // 调用 FixedUpdate 的频度常常超过 Update。如果帧率很低，可以每帧调用该函数多次；如果帧率很高，可能在帧之间完全不调用该函数。在 FixedUpdate 之后将立即进行所有物理计算和更新。
        // 在 FixedUpdate 内应用运动计算时，无需将值乘以 Time.deltaTime。这是因为 FixedUpdate 的调用基于可靠的计时器（独立于帧率）。
        private void FixedUpdate()
        // 每隔固定时间调用一次  一般用于物理运动
        {
            Debug.Log("FixedUpdate");
        }

        
        // LateUpdate 的常见用途是跟随第三人称摄像机。 如果在 Update 内让角色移动和转向，可以在 LateUpdate 中执行所有摄像机移动和旋转计算。这样可以确保角色在摄像机跟踪其位置之前已完全移动
        private void LateUpdate()
        // update 之后调用一次 LateUpdate 的常见用途是跟随第三人称摄像机。
        {
            Debug.Log("LateUpdate");
        }
    }
}