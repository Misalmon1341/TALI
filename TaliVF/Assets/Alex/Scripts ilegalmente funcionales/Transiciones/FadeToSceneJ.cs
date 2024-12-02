using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FadeToSceneJ : MonoBehaviour
{
    public GameObject fadePanel;
    public float fadeDuration = 5f;
    public string nextSceneName = "Jeremy Dream";
    public TextMeshProUGUI dialogueText;
    public string dialogueline;

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
            if (dialogueText != null && dialogueText.text == dialogueline)
            {
                isDialogueFinished = true;
            }

            yield return null;
        }

        StartCoroutine(FadeOutAndChangeScene());
    }

    private IEnumerator FadeOutAndChangeScene()
    {
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