// 变换矩阵测试
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
            transform.Rotate(30,60,90,Space.World);
            newMatrix = transform.localToWorldMatrix;
            Debug.Log("现在旋转: "+ExtractRotation(newMatrix).eulerAngles);
            incrementMatrix = Subtraction(newMatrix, originMatrix);
            Debug.Log("增量旋转: "+ExtractRotation(incrementMatrix).eulerAngles);
        }
        if (Input.GetKeyDown("c"))
        {
            // 测试原矩阵旋转 * 现矩阵旋转 是否能达到目标
            clone.rotation = ExtractRotation(originMatrix) * ExtractRotation(incrementMatrix);
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

    // 矩阵相减
    public Matrix4x4 Subtraction(Matrix4x4 newMatrix, Matrix4x4 originMatrix)
    {
        Matrix4x4 increment = new Matrix4x4();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                increment[i,j] = newMatrix[i,j] - originMatrix[i,j];
            }
        }

        return increment;
    }

}
