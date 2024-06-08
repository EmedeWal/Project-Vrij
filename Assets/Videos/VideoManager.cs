using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadNextScene();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex + 1);    
    }
}
