using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAtStart : MonoBehaviour
{
    public GameObject fadePanel; // Panel que se aclarar�
    public float fadeDuration = 3f; // Duraci�n del desvanecimiento
    private CanvasGroup canvasGroup; // Componente para controlar la opacidad

    void Start()
    {
        if (fadePanel != null)
        {
            canvasGroup = fadePanel.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = fadePanel.AddComponent<CanvasGroup>();
            }

            canvasGroup.alpha = 1f; // Aseg�rate de que el panel est� completamente opaco al inicio
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
            }
            yield return null;
        }

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f; // Aseg�rate de que el panel est� completamente transparente al final
        }

        fadePanel.SetActive(false); // Desactiva el panel para que no bloquee la interacci�n
    }
}