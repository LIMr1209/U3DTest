// Examples of VideoPlayer function
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerExample : MonoBehaviour
{
    private Texture _texture;
    private GameObject camera;
    void Start()
    {
        camera = GameObject.Find("Plane");
        var videoPlayer = camera.AddComponent<VideoPlayer>();

        videoPlayer.playOnAwake = false;

        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;

        videoPlayer.targetCameraAlpha = 0.5F;

        videoPlayer.url = "hts://cdn1.d3ingo.com/scene_rendering/user_fodder/220715/62d0d04298562afff5907582.mp4";
        

        videoPlayer.isLooping = true;
        Debug.Log(videoPlayer.width);

        videoPlayer.prepareCompleted += Prepared;
        videoPlayer.errorReceived += error;
        videoPlayer.Prepare();
        Debug.Log(videoPlayer.isPrepared);

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.

    }
    
    void Prepared(VideoPlayer videoPlayer) {
        Debug.Log(videoPlayer.width);
        videoPlayer.Play();
    }

    void error(VideoPlayer videoPlayer, string message)
    {
        Debug.Log(message);
    }
}