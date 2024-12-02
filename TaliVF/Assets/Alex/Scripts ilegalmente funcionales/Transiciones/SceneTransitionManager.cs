using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public GameObject fadePanel; 
    public float fadeDuration = 3f; 
    public EscenasLily escenasLilyScript; 
    public bool useFadeForThisScene = true; 

    private CanvasGroup canvasGroup; 

    void Start()
    {
        if (fadePanel != null)
        {
            canvasGroup = fadePanel.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = fadePanel.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0f; 
        }
    }

    public void TriggerSceneChange(string sceneFunctionName)
    {
        if (useFadeForThisScene)
        {
            StartCoroutine(FadeOutAndChangeScene(sceneFunctionName));
        }
        else
        {
            InvokeSceneFunction(sceneFunctionName);
        }
    }

    private IEnumerator FadeOutAndChangeScene(string sceneFunctionName)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            if (canvasGroup != null)
            {
                canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            }
            yield return null;
        }

        InvokeSceneFunction(sceneFunctionName);
    }

    private void InvokeSceneFunction(string sceneFunctionName)
    {
        if (escenasLilyScript != null)
        {
            var method = escenasLilyScript.GetType().GetMethod(sceneFunctionName);
            if (method != null)
            {
                method.Invoke(escenasLilyScript, null);
            }
            else
            {
                Debug.LogError("La función " + sceneFunctionName + " no existe en el script EscenasLily.");
            }
        }
    }
}