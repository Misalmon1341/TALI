using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScreen : MonoBehaviour
{
     public AudioSource menuAudio;
    public Animator introAnimator;  
    public float appearDuration = 2f; 
    public float disappearDuration = 3f; 
    public GameObject warningPanel;  
    public Text warningText;         

    void Start()
    {
        if (introAnimator != null)
        {
            DisplayWarningMessage(); 
            StartCoroutine(PlayIntroAndLoadMenu());
        }
        else
        {
            Debug.LogError("El Animator de la pantalla de introducción no está asignado.");
        }
    }

    private void DisplayWarningMessage()
    {
        if (warningPanel != null && warningText != null)
        {
            warningPanel.SetActive(true); 
            warningText.text = "Este material contiene escenas y situaciones que no pueden ser aptas para todo público, se recomienda discrecion...";
        }
        else
        {
            Debug.LogError("El panel de advertencia o el componente de texto no están asignados.");
        }
    }

    private IEnumerator PlayIntroAndLoadMenu()
    {
        introAnimator.SetTrigger("StartIntro");
        Debug.Log("Animación de aparición activada");

        yield return new WaitForSeconds(appearDuration);

        yield return new WaitForSeconds(1f);

        introAnimator.SetTrigger("EndIntro");
        Debug.Log("Animación de desaparición activada");

        yield return new WaitForSeconds(disappearDuration);

        if (warningPanel != null)
        {
            warningPanel.SetActive(false);
        }

        SceneManager.LoadScene("MainMenuScene");
    }
}
