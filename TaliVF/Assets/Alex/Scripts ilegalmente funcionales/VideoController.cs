using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += EndReached;
        }
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("NextScene"); 
    }
}

