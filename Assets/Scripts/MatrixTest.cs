// 变换矩阵测试

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatrixTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.localToWorldMatrix.GetT());
        Debug.Log(transform.localToWorldMatrix.GetPosition());
        Debug.Log(transform.localToWorldMatrix.GetS());
        Debug.Log(transform.localToWorldMatrix.GetR());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
