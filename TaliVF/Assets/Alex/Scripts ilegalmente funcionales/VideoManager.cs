using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public VideoClip firstVideo; 
    public VideoClip loopVideo; 
    public GameObject buttonPanel; 

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.clip = firstVideo; 
            videoPlayer.isLooping = false; 
            videoPlayer.Play(); 
            videoPlayer.loopPointReached += OnFirstVideoEnd; 
        }

        if (buttonPanel != null)
        {
            buttonPanel.SetActive(false); 
        }
    }

    void OnFirstVideoEnd(VideoPlayer vp)
{
    Debug.Log("Primer video terminado. Cambiando al segundo video con loop.");

    videoPlayer.Stop(); 
    videoPlayer.clip = loopVideo; 
    videoPlayer.Prepare(); 
    videoPlayer.isLooping = true; 

    videoPlayer.prepareCompleted += PlaySecondVideo; 
    if (buttonPanel != null)
    {
        buttonPanel.SetActive(true); 
    }
    else
    {
        Debug.LogWarning("El panel de botones no está asignado.");
    }
}

void PlaySecondVideo(VideoPlayer vp)
{
    Debug.Log("Segundo video preparado. Reproduciendo ahora.");
    videoPlayer.Play();
}

    public void LoadOptionA()
    {
        SceneManager.LoadScene("OptionAScene"); 
    }

    public void LoadOptionB()
    {
        SceneManager.LoadScene("OptionBScene"); 
    }
}