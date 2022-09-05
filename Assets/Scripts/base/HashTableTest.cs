// 哈希测试

using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class HashTableTest : MonoBehaviour
    {
        private Hashtable _data = new Hashtable();

        
        /*添加数据时Hashtable快。频繁调用数据时Dictionary快。

        结论：
        Dictionary<K,V>是泛型的，当K或V是值类型时，其速度远远超过Hashtable。

        补充：C# 哈希表Hashtable与字典表Dictionary<K,V>的比较。

        hashtable和dictionary的探讨

        一、Hashtable 和 Dictionary <K, V> 类型
        1）：单线程程序中推荐使用 Dictionary, 有泛型优势, 且读取速度较快, 容量利用更充分.

            2）：多线程程序中推荐使用 Hashtable, 默认的 Hashtable 允许单线程写入, 多线程读取, 对 Hashtable 进一步调用 Synchronized()方法可以获得完全线程安全的类型. 而Dictionary 非线程安全, 必须人为使用 lock 语句进行保护, 效率大减.

        3）：Dictionary 有按插入顺序排列数据的特性 (注: 但当调用 Remove() 删除过节点后顺序被打乱), 因此在需要体现顺序的情境中使用 Dictionary 能获得一定方便.

            在使用哈希表保存集合元素（一种键/值对）时，首先要根据键自动计算哈希代码，以确定该元素的保存位置，再把元素的值放入相应位置所指向的存储桶中。在查找时，再次通过键所对应的哈希代码到特定存储桶中搜索，这样将大大减少为查找一个元素进行比较的次数。

        HashTable中的key/value均为object类型，由包含集合元素的存储桶组成。存储桶是 HashTable中各元素的虚拟子组，与大多数集合中进行的搜索和检索相比，存储桶可令搜索和检索更为便捷。每一存储桶都与一个哈希代码关联，该哈希代码是使用哈希函数生成的并基于该元素的键。HashTable的优点就在于其索引的方式，速度非常快。如果以任意类型键值访问其中元素会快于其他集合，特别是当数据量特别大的时候，效率差别尤其大。

        HashTable的应用场合有：做对象缓存，树递归算法的替代，和各种需提升效率的场合。Dictionary<Tkey,Tvalue>是Hastbale的泛型实现。 */
        private void Start()
        {
            // _data.Add("张三", 18);
            // _data.Add("李四", "总裁");
            // Dictionary<string, AssetBundle> test = new Dictionary<string, AssetBundle>();
            // _data.Add("王五", test);
            _data.Add("北京", "帝都"); //添加keyvalue键值对
            _data.Add("上海", "魔都");
            _data.Add("广州", "省会");
            _data.Add("深圳", "特区");
            string capital = (string)_data["北京"];
            Debug.Log(capital);
            Debug.Log(_data.Contains("上海")); //判断哈希表是否包含特定键,其返回值为true或false
            _data.Remove("深圳"); //移除一个keyvalue键值对
            // _data.Clear(); //移除所有元素
            // 遍历键
            foreach (string key in _data.Keys)
            {
                Debug.Log(key);
            }
            // 遍历值
            foreach (object value in _data.Values)
            {
                Debug.Log(value);
            }
            // 对哈希表进行排序
            ArrayList akeys=new ArrayList(_data.Keys); 
            akeys.Sort(); //按字母顺序进行排序
            foreach(string key in akeys)
            {
                Debug.Log(key + ": " + _data[key]); //排序后输出
            }

            // 由于Hashtable每个元素都是一个键/值对，因此元素类型既不是键的类型，也不是值的类型，而是DictionaryEntry类型。
            foreach (DictionaryEntry de in _data)
            {
                Debug.Log(de.Key.ToString());
                Debug.Log(de.Value.ToString());
            }
            
            IDictionaryEnumerator enumerator = _data.GetEnumerator();
  
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Key);    // Hashtable关健字
                Console.WriteLine(enumerator.Value);   // Hashtable值
            }
        }
    }
}