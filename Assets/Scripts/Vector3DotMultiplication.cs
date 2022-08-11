using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3DotMultiplication : MonoBehaviour
{
    // Start is called before the first frame update
    // 点乘  点积 内积    各分量 乘积和  a·b = |a|·|b|cos<a,b>  
    // 叉乘  叉积 外积   结果为两个向量所组成面的垂直向量 模长为两向量模长乘积再乘夹角的正弦值
    public Transform t1;
    public Transform t2;
    public float angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dot = Vector3.Dot(t1.position.normalized, t2.position.normalized);
        // dot == 1 方向相同 dot == -1 方向相反 dot == 0 垂直   
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg; // x 轴 和 z轴的角度  0-180 度 
        // dot == 0.5 angel == 60
        Debug.DrawLine(Vector3.zero, t1.position, Color.red);
        Debug.DrawLine(Vector3.zero, t2.position, Color.blue);
        Vector3 cross = Vector3.Cross(t1.position, t2.position);
        Debug.DrawLine(Vector3.zero, cross, Color.green);
        if (cross.y < 0)
        {
            angle = 360 - angle;
        }

    }
}
