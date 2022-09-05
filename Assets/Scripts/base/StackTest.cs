// 栈测试

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    // 栈 后进先出  浏览器 撤销  push 压栈 pop 弹栈 peek 读栈顶 读取但不移除顶部对象  count 大小
    
    /*1	public virtual void Clear();
    从 Stack 中移除所有的元素。
    2	public virtual bool Contains( object obj );
    判断某个元素是否在 Stack 中。
    3	public virtual object Peek();
    返回在 Stack 的顶部的对象，但不移除它。
    4	public virtual object Pop();
    移除并返回在 Stack 的顶部的对象。
    5	public virtual void Push( object obj );
    向 Stack 的顶部添加一个对象。
    6	public virtual object[] ToArray();
    复制 Stack 到一个新的数组中。*/
    public class StackTest : MonoBehaviour
    {
        private Stack stack = new Stack();

        private void Start()
        {
            stack.Push("你好");
            stack.Push("傻逼");
            object haha = stack.Peek();
            object test = stack.Pop();
            test = stack.Pop();
            Debug.Log(test);
            Debug.Log(haha);
        }
        
    }
}