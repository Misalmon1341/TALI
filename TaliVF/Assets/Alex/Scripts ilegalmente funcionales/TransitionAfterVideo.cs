using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class TransitionAfterVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public CanvasGroup fadePanel; 
    public float fadeDuration = 3f; 
    [Tooltip("Nombre de la escena a la que se cambiará después del video")]
    public string nextSceneName = "NextScene"; 

    private bool isFading = false; 

    void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.alpha = 0f;
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (!isFading) 
        {
            isFading = true;
            StartCoroutine(FadeAndLoadScene());
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            if (fadePanel != null)
            {
                fadePanel.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            }
            yield return null;
        }

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la siguiente escena no está configurado en el Inspector.");
        }
    }
}