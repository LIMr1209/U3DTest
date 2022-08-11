// 判断是否在摄像机渲染范围

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRendering : MonoBehaviour
{
    public GameObject obj;
    Collider objCollider;

    Camera cam;
    public Plane[] planes;

    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam); // 计算平截头体平面。此函数采用给定相机的视锥体并返回形成它的六个平面。
        objCollider =  GetComponent<Collider>();
    }

    void Update()
    {
        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))   // 如果边界框在平面内或与任何平面相交，将返回 true。
        {
            Debug.Log(obj.name + " has been detected!");
        }
        else
        {
            Debug.Log("Nothing has been detected");
        }
    }
}
