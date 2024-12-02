using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour
{
    public GameObject fadePanel; // Panel que se oscurecerá
    public float fadeDuration = 3f; // Duración del desvanecimiento
    public Button[] buttons; // Array de botones que activarán la transición
    public string[] sceneNames; // Escenas asociadas a cada botón (en el mismo orden)

    public CanvasGroup canvasGroup; // Controla la opacidad del fadePanel

    void Start()
    {
        // Configura el CanvasGroup del fadePanel
        if (fadePanel != null)
        {
            canvasGroup = fadePanel.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = fadePanel.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0f; // Asegúrate de que el panel esté transparente al inicio
        }

        // Asignar la transición a los botones
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Necesario para evitar problemas de referencia en las lambdas
            if (buttons[index] != null)
            {
                buttons[index].onClick.AddListener(() => StartCoroutine(FadeOutAndChangeScene(sceneNames[index])));
            }
        }
    }

    private IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        float elapsedTime = 0f;

        // Oscurecer el panel
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            if (canvasGroup != null)
            {
                canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            }
            yield return null;
        }

        // Cambiar a la siguiente escena después del desvanecimiento
        SceneManager.LoadScene(sceneName);
    }
}