// lookat 测试

using UnityEngine;

public class LookAtTest : MonoBehaviour
{
    private Transform _follow;

    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        _follow = GameObject.Find("Cube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.DrawLine (Vector3.zero, _follow.position-transform.position,Color.yellow);
        // Vector3 dir=(_follow.position-transform.position).normalized; //起始点到目标点的方向向量
        // if (Input.GetKeyDown("a"))
        // {
        //     transform.Translate(dir);
        // }
        float x = Mathf.Sin(30 * Mathf.Deg2Rad) * -10;
        float z = Mathf.Cos(30 * Mathf.Deg2Rad) * -10;
        Vector3 worldPoint = transform.TransformPoint(x, 0, z);
        Debug.DrawLine(transform.position, worldPoint);
        // transform.LookAt(_follow);
        // transform.Rotate(new Vector3(0,90,0));
        // Vector3 dir=(_follow.position-transform.position).normalized; //起始点到目标点的方向向量
        // float angle=Vector2.SignedAngle(Vector2.left, dir);
        // Debug.Log(angle);
        // var relativePosition = transform.InverseTransformDirection(_follow.position);
        //
        // // you want to eliminate the local difference in Y direction
        // relativePosition.y = 0;
        //
        // // since you are right and LookAt expects a world position after eliminating the local Y difference 
        // // we convert it back to world space
        // var targetPosition = transform.TransformPoint(relativePosition);
        //
        // transform.LookAt(targetPosition, _follow.transform.up);
    }
}
