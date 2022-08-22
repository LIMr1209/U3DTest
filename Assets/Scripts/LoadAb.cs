using System.Collections;
using System.Collections.Generic;
using System.IO;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAb : MonoBehaviour
{
    // Start is called before the first frame update
    private AssetBundle _assetBundle;
    private Scene scene;
    private bool load;
    void Start()
    {
        string yilai1 = Path.Combine(Application.dataPath, "AssetBundles", "scene2", "1.ab");
        AssetBundle _assetBundleyilai1 = AssetBundle.LoadFromFile(yilai1);
        string[] scenePaths1 = _assetBundleyilai1.GetAllScenePaths();
        string sceneName1 = Path.GetFileNameWithoutExtension(scenePaths1[0]);
        SceneManager.LoadScene(sceneName1,  LoadSceneMode.Additive);
        
        string yilai2 = Path.Combine(Application.dataPath, "AssetBundles", "scene2", "2.ab");
        AssetBundle _assetBundleyilai2 = AssetBundle.LoadFromFile(yilai2);
        string[] scenePaths2 = _assetBundleyilai2.GetAllScenePaths();
        string sceneName2 = Path.GetFileNameWithoutExtension(scenePaths2[0]);
        SceneManager.LoadScene(sceneName2,  LoadSceneMode.Additive);
        
        string yilai3 = Path.Combine(Application.dataPath, "AssetBundles", "scene2", "scene.ab");
        AssetBundle _assetBundleyilai3 = AssetBundle.LoadFromFile(yilai3);
        // _assetBundleyilai2.LoadAllAssets();
        string[] scenePaths3 = _assetBundleyilai3.GetAllScenePaths();
        string sceneName3 = Path.GetFileNameWithoutExtension(scenePaths3[0]);
        
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        scene = SceneManager.LoadScene(sceneName3, parameters);
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.isLoaded && !load)
        {
            SceneManager.SetActiveScene(scene);
            Debug.Log(scene.GetRootGameObjects().Length);
            foreach (var obj in scene.GetRootGameObjects())
            {
                ShaderProblem.ResetMeshShader(obj);
            }
            load = true;
            Material material = RenderSettings.skybox;
            material.shader = Shader.Find(material.shader.name);
            RenderSettings.skybox = material;
            DynamicGI.UpdateEnvironment();
        }
        
    }
}
