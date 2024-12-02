using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToSceneWithMusicJ : MonoBehaviour
{
    public GameObject fadePanel; 
    public float fadeDuration = 5.2f; 
    public string nextSceneName = "EndScene"; 
    public TextMeshProUGUI dialogueText; 
    public AudioSource transitionMusic; 

    private CanvasGroup canvasGroup; 
    private bool isDialogueFinished = false;

    void Start()
    {
        if (fadePanel != null)
        {
            canvasGroup = fadePanel.GetComponent<CanvasGroup>();

            if (canvasGroup == null)
            {
                canvasGroup = fadePanel.AddComponent<CanvasGroup>();
            }

            StartCoroutine(WaitForDialogueToEnd());
        }
    }

    private IEnumerator WaitForDialogueToEnd()
    {
        while (!isDialogueFinished)
        {
            if (dialogueText != null && dialogueText.text == "¿M-mamá…?")
            {
                isDialogueFinished = true;
            }

            yield return null;
        }

        StartCoroutine(PlayMusicAndFadeOut());
    }

    private IEnumerator PlayMusicAndFadeOut()
    {
        if (transitionMusic != null)
        {
            transitionMusic.Play();
        }

        float elapsedTime = 0f;

        canvasGroup.alpha = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
