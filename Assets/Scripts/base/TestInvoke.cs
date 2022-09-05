// Invoke 测试

using System.Collections;
using UnityEngine;
namespace DefaultNamespace
{
    public class TestInvoke : MonoBehaviour
    {
        public GameObject obj;
        public GameObject ball;
        [Range(0f, 2f)] public float timeScale = 1f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // invoke 不能传参
                // Invoke("SpawnCube", 2f);
                // Instantiate(ball, new Vector3(0, 5, 0), Quaternion.identity);
                InvokeRepeating("SpawnCube", 3,2);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                CancelInvoke("SpawnCube");
            }

            // Time.timeScale = timeScale;
        }

        
        private void SpawnCube()
        {
            float x = Random.Range(-1.0f, 1.0f);
            float y = Random.Range(-1.0f, 1.0f);
            Instantiate(obj, new Vector3(x, y, 0), Quaternion.identity);
        }

        private void OnGUI()
        {
            // GUILayout.TextArea("Game Time" + Time.time.ToString(), 200);
            // GUILayout.TextArea("Real Time" + Time.realtimeSinceStartup.ToString(), 200);
            GUILayout.TextArea(IsInvoking("SpawnCube").ToString(), 200);
        }
    }
}