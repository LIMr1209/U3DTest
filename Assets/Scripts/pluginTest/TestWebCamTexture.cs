// 摄像头 贴图

using UnityEngine;

public class TestWebCamTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);
        WebCamTexture webcam = new WebCamTexture(devices[0].name);
        GetComponent<Renderer>().material.mainTexture = webcam;
        webcam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
