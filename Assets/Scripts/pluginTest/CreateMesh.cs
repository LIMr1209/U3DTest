// 脚本创建网格对象

using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        Mesh targetMesh = cube.GetComponent<MeshFilter>().mesh;
        List<Vector3> vertices = new List<Vector3>();
        targetMesh.GetVertices(vertices);
        List<Vector2> uvs = new List<Vector2>();
        targetMesh.GetUVs(0,uvs);
        List<int> triangles = new List<int>();
        targetMesh.GetTriangles(triangles, 0);
        
        // int[] triangles = new int[0];           //声明三角形数组
        Mesh mesh = new Mesh();                //声明网格
        //对网格进行赋值引用
        mesh.SetVertices(vertices);
        mesh.SetUVs(0,uvs);
        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        GetComponent<MeshFilter>().mesh = mesh;
        
         // var dataArray = Mesh.AllocateWritableMeshData(1);
         // var data = dataArray[0];
         // using (var test = Mesh.AcquireReadOnlyMeshData(targetMesh))
         // {
         //     var test1 = test[0];
         //     // prints "2"
         //     Debug.Log(test1.vertexCount);
         //     var verts = test[0].GetVertexData<Vertex>();
         //     data.SetVertexBufferParams(verts.Length,
         //         new VertexAttributeDescriptor(VertexAttribute.Position),
         //         new VertexAttributeDescriptor(VertexAttribute.Normal, stream: 1));
         //     var pos = data.GetVertexData<Vector3>();
         //     
         //     for (int i = 0; i < verts.Length; i++)
         //     {
         //         pos[i] = verts[i].position;
         //     }
         //     data.SetIndexBufferParams(verts.Length, IndexFormat.UInt16);
         //     var ib = data.GetIndexData<ushort>();
         //     for (ushort i = 0; i < ib.Length; ++i)
         //         ib[i] = i;
         //     // One sub-mesh with all the indices.
         //     data.subMeshCount = 1;
         //     data.SetSubMesh(0, new SubMeshDescriptor(0, ib.Length));
         //     // Create the mesh and apply data to it:
         //     var mesh = new Mesh();
         //     mesh.name = "test";
         //     Mesh.ApplyAndDisposeWritableMeshData(dataArray, mesh);
         //     mesh.RecalculateNormals();
         //     mesh.RecalculateBounds();
         //     GetComponent<MeshFilter>().mesh = mesh;
         // }
    }

    // Update is called once per frame
    void Update()
    {
    }
}