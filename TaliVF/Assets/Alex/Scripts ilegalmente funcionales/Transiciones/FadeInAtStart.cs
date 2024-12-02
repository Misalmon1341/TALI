using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAtStart : MonoBehaviour
{
    public GameObject fadePanel; // Panel que se aclarará
    public float fadeDuration = 3f; // Duración del desvanecimiento
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

            canvasGroup.alpha = 1f; // Asegúrate de que el panel esté completamente opaco al inicio
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
            canvasGroup.alpha = 0f; // Asegúrate de que el panel esté completamente transparente al final
        }

        fadePanel.SetActive(false); // Desactiva el panel para que no bloquee la interacción
    }
}