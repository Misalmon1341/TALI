using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public AudioSource creditsAudio;
    public Animator creditsAnimator;
    public GameObject finalPanel;  

    private bool isEnding = false;

    void Start()
    {
        if (creditsAudio != null)
        {
            creditsAudio.Play();
        }
        
        if (creditsAnimator != null)
        {
            creditsAnimator.SetTrigger("StartCredits");
        }
    }

    void Update()
    {
        if (creditsAudio != null && !creditsAudio.isPlaying && !isEnding)
        {
            StartCoroutine(EndCreditsSequence());
            isEnding = true;  
        }
    }

    private IEnumerator EndCreditsSequence()
    {
        if (finalPanel != null)
        {
            finalPanel.SetActive(true);
        }

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenuScene");
        
    }
}