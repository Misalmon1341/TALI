using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OptionB : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject buttonPanel;
    public VideoClip firstVideo;
    public string nextSceneName = "LyliPov15";

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.clip = firstVideo; 
            videoPlayer.Play(); 
            videoPlayer.loopPointReached += OnVideoEnd; 
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("LyliPov15");
    }
}
