// 队列测试

using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    // 队列 先进先出 Enqueue 入队  Dequeue 出队 peek 读队首 count 数量
    public class QueueTest : MonoBehaviour
    {
        /*1	public virtual void Clear();
        从 Queue 中移除所有的元素。
        2	public virtual bool Contains( object obj );
        判断某个元素是否在 Queue 中。
        3	public virtual object Dequeue();
        移除并返回在 Queue 的开头的对象。
        4	public virtual void Enqueue( object obj );
        向 Queue 的末尾添加一个对象。
        5	public virtual object[] ToArray();
        复制 Queue 到一个新的数组中。
        6	public virtual void TrimToSize();
        设置容量为 Queue 中元素的实际个数。*/
        private Queue _queue = new Queue();

        private void Start()
        {
            _queue.Enqueue("哈哈");
            _queue.Enqueue("你好");
            object test = _queue.Peek();
            Debug.Log(test);
        }
    }
}