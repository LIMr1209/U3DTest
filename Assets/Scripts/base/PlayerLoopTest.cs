using System;
using System.Text;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;


// https://medium.com/@thebeardphantom/unity-2018-and-playerloop-5c46a12a677
// 在 Unity 5.X（特别是 5.0）之前，对应用程序生命周期的控制基本上是不存在的。对于应用程序启动/初始化代码，您可以创建一个在“脚本执行顺序”窗口中排序最早并使用 Awake 的脚本，但您会遇到问题。带有该脚本的对象需要存在于需要运行初始化代码的任何场景中，这种状态在编辑器中很难维护。很容易忘记对象需要存在，并且需要向从事该项目的其他开发人员解释功能。
// 在 Unity 5.0 中，我们提供了RuntimeInitializeOnLoad，这是一个放置在静态函数上的属性，然后在运行时自动执行。无论场景设置如何，它都是确保某些代码始终执行的万无一失的方法。在 5.2 中，添加了RuntimeInitializeLoadType枚举形式的可选参数，允许开发人员决定是否应该在加载初始场景之前或之后执行标记的函数（在发送 Awake 消息之前）。有了这个单一功能，在没有场景的情况下使用 Unity 突然变得可行，稍微接近于使用游戏框架，例如 MonoGame。
// 然而，每帧更新的系统（一些更频繁）仍然遥不可及。这些系统也称为主/游戏更新循环。系统不能因为性能而被禁用，不能根据偏好重新排序，最重要的是，新的任意系统不能被添加到更新循环中。当然，您总是可以使用像Update、FixedUpdate和LateUpdate这样的函数来连接到内置更新系统，但这些总是发生在 Unity 的内部系统之间，超出了用户的控制范围。
// 在 Unity 2018.1 中，引入了PlayerLoop和PlayerLoopSystem类以及UnityEngine.Experim ental.PlayerLoop命名空间，允许用户删除和重新排序引擎更新系统，以及实施自定义系统。

namespace DefaultNamespace
{
    public class PlayerLoopTest : MonoBehaviour
    {
        
        // [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            Debug.Log ("在第一个场景加载前");
        } 

        // [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.AfterSceneLoad )]
        static void OnAfterSceneLoadRuntimeMethod()
        {
            Debug.Log ("第一个场景加载后");
        } 

        
        
        //  标记[RuntimeInitializeOnLoadMethod]的方法在游戏加载后被调用
        // [RuntimeInitializeOnLoadMethod]
        private static void AppStart()
        {
            // PlayerLoopSystem是一个以递归、树状结构组织的结构。从此对象中，您可以获得有关系统的一些信息：
            // PlayerLoopSystem loop = PlayerLoop.GetDefaultPlayerLoop();
            
            
            // 一个简单的自定义 PlayerLoopSystem
            // var systemRoot = new PlayerLoopSystem();
            // systemRoot.subSystemList = new PlayerLoopSystem[]
            // {
            //     new PlayerLoopSystem()
            //     {
            //         updateDelegate = CustomUpdate,
            //         type = typeof(Update.ScriptRunBehaviourUpdate)
            //     },
            // };
            // PlayerLoop.SetPlayerLoop(systemRoot);
            
            // 将一个默认系统重新添加到组合中
            // var defaultSystems = PlayerLoop.GetDefaultPlayerLoop();
            // var physicsFixedUpdateSystem = FindSubSystem<FixedUpdate.PhysicsFixedUpdate>(defaultSystems);
            // var systemRoot = new PlayerLoopSystem();
            // systemRoot.subSystemList = new PlayerLoopSystem[]
            // {
            //     physicsFixedUpdateSystem,
            //     new PlayerLoopSystem()
            //     {
            //         updateDelegate = CustomUpdate,
            //         type = typeof(Update.ScriptRunBehaviourUpdate)
            //     },
            // };
            // PlayerLoop.SetPlayerLoop(systemRoot);
            
            
            // 将我们按类型找到的系统替换为我们自己的系统
            var defaultSystems = PlayerLoop.GetDefaultPlayerLoop();
            var customUpdate = new PlayerLoopSystem()
            {
                updateDelegate = CustomUpdate,
                type = typeof(Update.ScriptRunBehaviourUpdate)
            };
            ReplaceSystem<Update.ScriptRunBehaviourUpdate>(ref defaultSystems, customUpdate);
            PlayerLoop.SetPlayerLoop(defaultSystems);
            
            // 打印循环
            PlayerLoopSystem loop = PlayerLoop.GetCurrentPlayerLoop();
            var sb = new StringBuilder();
            RecursivePlayerLoopPrint(loop, sb, 0);
            Debug.Log(sb.ToString());
        }

        private static void CustomUpdate()
        {
            Debug.Log("Custom update running!");
        }

        private static void RecursivePlayerLoopPrint(PlayerLoopSystem def, StringBuilder sb, int depth)
        {
            if (depth == 0)
            {
                sb.AppendLine("ROOT NODE");
            }
            else if (def.type != null)
            {
                for (int i = 0; i < depth; i++)
                {
                    sb.Append("\t");
                }
                sb.AppendLine(def.type.Name);
            }
            if (def.subSystemList != null)
            {
                depth++;
                foreach (var s in def.subSystemList)
                {
                    RecursivePlayerLoopPrint(s, sb, depth);
                }
                depth--;
            }
        }
        
        private static PlayerLoopSystem FindSubSystem<T>(PlayerLoopSystem def)
        {
            if (def.type == typeof(T))
            {
                return def;
            }
            if (def.subSystemList != null)
            {
                foreach (var s in def.subSystemList)
                {
                    var system = FindSubSystem<T>(s);
                    if (system.type == typeof(T))
                    {
                        return system;
                    }
                }
            }
            return default(PlayerLoopSystem);
        }
        
        private static bool ReplaceSystem<T>(ref PlayerLoopSystem system, PlayerLoopSystem replacement)
        {
            if (system.type == typeof(T))
            {
                system = replacement;
                return true;
            }
            if (system.subSystemList != null)
            {
                for (var i = 0; i < system.subSystemList.Length; i++)
                {
                    if (ReplaceSystem<T>(ref system.subSystemList[i], replacement))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        
    }
    
    
}