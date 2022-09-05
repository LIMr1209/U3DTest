// 加载gltf 自适应放到球体内部

using System;
using System.Collections.Generic;
using System.Linq;
using Piglet;
using UnityEngine;

namespace DefaultNamespace
{
    public class ChildrenBounds : MonoBehaviour
    {
        public static ChildrenBounds instance;
        private List<GltfImportTask> _tasks = new List<GltfImportTask>();
        public GameObject bubble;
        public GameObject cube;
        public Bounds bounds;
        public Bounds bubblebounds;


        private void Awake()
        {
            instance = this;
        }


        private void Start()
        {
            string uri = "https://cdn1.d3ingo.com/scene_rendering/user_fodder/220427/6268aa45534ed7ed0344372d.glb";
            // string uri = "https://cdn1.d3ingo.com/scene_rendering/user_fodder/220426/6267697c1cad7926e6f5f5af.glb";
            
            AddGltfTask(uri, (gameObject) =>
            {
                float d = bubble.GetComponent<MeshRenderer>().bounds.size.x;
                float dimensions = (float)(d / Math.Sqrt(3)); // 正方体对角线公式计算正方体尺寸
                Debug.Log(cube.GetComponent<MeshRenderer>().bounds.size.x);
                cube.transform.SetParent(bubble.transform, false);
                float loadingBaseDimensions = cube.GetComponent<MeshRenderer>().bounds.size.x;
                Debug.Log(loadingBaseDimensions);
                // float loadingDimensions = dimensions / loadingBaseDimensions ;
                // cube.transform.localScale *= loadingDimensions;
                // bubblebounds = new Bounds(bubble.transform.position, new Vector3(dimensions, dimensions, dimensions));
                // gameObject.transform.SetParent(bubble.transform, false);
                // // 泡泡尺寸
                // bounds = GetMaxBounds2(gameObject);
                // float maxD = Math.Max(bounds.size.x, bounds.size.y);
                // float maxDis = Math.Max(bounds.size.z, maxD);    
                // float proportion = dimensions / maxDis;
                // gameObject.transform.localScale = new Vector3(proportion, proportion, proportion);
                // bounds = GetMaxBounds2(gameObject);
                // gameObject.transform.position -= bounds.center - gameObject.transform.position;
                // bounds = GetMaxBounds2(gameObject);
                // Debug.Log(111);
            });
        }

        private void Update()
        {
            foreach (var i in _tasks)
            {
                i.MoveNext();
            }

            if (bounds.extents != Vector3.zero)
            {
                DrawBounds(bounds, Color.blue);
            }
            
            if (bubblebounds.extents != Vector3.zero)
            {
                DrawBounds(bubblebounds, Color.green);
            }
        }
        
        public Bounds GetMaxBounds2(GameObject g) {
            var renderers = g.GetComponentsInChildren<Renderer>();
            if (renderers.Length == 0) return new Bounds(g.transform.position, Vector3.zero);
            var b = renderers[0].bounds;
            foreach (Renderer r in renderers) {
                b.Encapsulate(r.bounds);
            }
            return b;
        }


        public Bounds GetMaxBounds(GameObject gameObject)
        {
            Bounds t;
            MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            List<float> maxX = new List<float>();
            List<float> maxY = new List<float>();
            List<float> maxZ = new List<float>();
            List<float> minX = new List<float>();
            List<float> minY = new List<float>();
            List<float> minZ = new List<float>();
            foreach (var i in meshRenderers)
            {
                maxX.Add(i.bounds.max.x);
                maxY.Add(i.bounds.max.y);
                maxZ.Add(i.bounds.max.z);
                
                minX.Add(i.bounds.min.x);
                minY.Add(i.bounds.min.y);
                minZ.Add(i.bounds.min.z);
            }

            float maxXF = maxX.Max();
            float maxYF = maxY.Max();
            float maxZF = maxZ.Max();
            float minXF = minX.Min();
            float minYF = minY.Min();
            float minZF = minZ.Min();
            t = new Bounds(new Vector3((maxXF + minXF) / 2, (maxYF + minYF) / 2, (maxZF + minZF) / 2), new Vector3(maxXF - minXF, maxYF - minYF, maxZF - minZF));
            return t;
        }

        void DrawBounds(Bounds b,  Color color, float delay=0)
        {
            // bottom
            var p1 = new Vector3(b.min.x, b.min.y, b.min.z);
            var p2 = new Vector3(b.max.x, b.min.y, b.min.z);
            var p3 = new Vector3(b.max.x, b.min.y, b.max.z);
            var p4 = new Vector3(b.min.x, b.min.y, b.max.z);

            Debug.DrawLine(p1, p2, color, delay);
            Debug.DrawLine(p2, p3, color, delay);
            Debug.DrawLine(p3, p4, color, delay);
            Debug.DrawLine(p4, p1, color, delay);

            // top
            var p5 = new Vector3(b.min.x, b.max.y, b.min.z);
            var p6 = new Vector3(b.max.x, b.max.y, b.min.z);
            var p7 = new Vector3(b.max.x, b.max.y, b.max.z);
            var p8 = new Vector3(b.min.x, b.max.y, b.max.z);

            Debug.DrawLine(p5, p6, color, delay);
            Debug.DrawLine(p6, p7, color, delay);
            Debug.DrawLine(p7, p8, color, delay);
            Debug.DrawLine(p8, p5, color, delay);

            // sides
            Debug.DrawLine(p1, p5, color, delay);
            Debug.DrawLine(p2, p6, color, delay);
            Debug.DrawLine(p3, p7, color, delay);
            Debug.DrawLine(p4, p8, color, delay);
        }

        public void AddGltfTask(string url ,Action<GameObject> action)
        {
            GltfImportTask task = RuntimeGltfImporter.GetImportTask(url);
            task.OnCompleted = model =>
            {
                action(model);
            };
            _tasks.Add(task);
        }
        
        
    }
}