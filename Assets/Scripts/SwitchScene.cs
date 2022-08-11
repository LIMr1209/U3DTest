// 切换场景

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update

    bool _navMesh1Loaded;
    bool _navMesh2Loaded;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GameObject light = FindObjectOfType<Light>().gameObject;
        DontDestroyOnLoad(light);
    }

    void OnGUI()
    {
        if (GUILayout.Button("Load NavMesh 1"))
        {
            if (_navMesh2Loaded)
                SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene(0);
            _navMesh1Loaded = true;
        }

        if (GUILayout.Button("Load NavMesh 2"))
        {
            if (_navMesh1Loaded)
                SceneManager.UnloadSceneAsync(0);
            SceneManager.LoadScene(1);
            _navMesh2Loaded = true;
        }
    }
}