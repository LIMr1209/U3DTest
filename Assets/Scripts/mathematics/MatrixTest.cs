// 变换矩阵测试

using Unity.VisualScripting;
using UnityEngine;

public class MatrixTest : MonoBehaviour
{
    public Matrix4x4 originMatrix;
    public Matrix4x4 newMatrix;
    public Matrix4x4 incrementMatrix;

    public Transform clone;
    // Start is called before the first frame update
    void Start()
    {
        originMatrix = transform.localToWorldMatrix;
        Debug.Log("原旋转: "+ExtractRotation(originMatrix).eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            transform.Translate(5,5,5);
            transform.Rotate(30,60,90,Space.World);
            Vector3 originScale = transform.localScale;
            transform.localScale = new Vector3(2, 1.5f, 2);
            newMatrix = transform.localToWorldMatrix;
            incrementMatrix = Subtraction(newMatrix, originMatrix);
            Vector3 position = incrementMatrix.GetPosition();
            Debug.Log("增量旋转: "+incrementMatrix.GetR().eulerAngles);
            Debug.Log("增量位移: "+new Vector3(position.x*originScale.x, position.y*originScale.y, position.z*originScale.z)); // 受缩放影响
            Debug.Log("增量缩放: "+incrementMatrix.GetS());  // 受旋转影响
        }
        if (Input.GetKeyDown("c"))
        {
            // 测试原矩阵旋转 * 现矩阵旋转 是否能达到目标
            Vector3 originScale = originMatrix.GetS();
            Vector3 incrementScale = incrementMatrix.GetS();
            Vector3 position = incrementMatrix.GetPosition();
            clone.rotation = originMatrix.GetR() * incrementMatrix.GetR();
            clone.position = originMatrix.GetT() + new Vector3(position.x * originScale.x, position.y * originScale.y,
                position.z * originScale.z);
            clone.localScale = new Vector3(originScale.x * incrementScale.x, originScale.y * incrementScale.y,
                originScale.z * incrementScale.z);
        }
        
    }
    
    public static Quaternion ExtractRotation(Matrix4x4 matrix)
    {
        Vector3 forward;
        forward.x = matrix.m02;
        forward.y = matrix.m12;
        forward.z = matrix.m22;
 
        Vector3 upwards;
        upwards.x = matrix.m01;
        upwards.y = matrix.m11;
        upwards.z = matrix.m21;
 
        return Quaternion.LookRotation(forward, upwards);
    }

    // 增量
    public Matrix4x4 Subtraction(Matrix4x4 newMatrix, Matrix4x4 originMatrix)
    {
        Matrix4x4 increment = originMatrix.inverse * newMatrix;
        return increment;
    }

}
