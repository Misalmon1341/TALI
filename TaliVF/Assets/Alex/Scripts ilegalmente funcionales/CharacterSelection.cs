using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CharacterSelection : MonoBehaviour
{
    public Animator characterAnimator;  
    public Animator buttonAnimator; 
    public Animator fadeAnimator;     
    public CanvasGroup fadePanel;       
    public float fadeDuration = 3f;     
    private bool isBoySelected = false;
    private bool isGirlSelected = false;
    public AudioSource menuAudio;

    void Start()
    {
        if (buttonAnimator == null)
        {
            buttonAnimator = GetComponent<Animator>();
        }
      
    }

    public void SelectBoy()
    {
        isBoySelected = true;
        StartCoroutine(PlayCharacterAnimationAndTransition("Jeremy"));
    }

    public void SelectGirl()
    {
        isGirlSelected = true;
        StartCoroutine(PlayCharacterAnimationAndTransition("Lily"));
    }
    

    private IEnumerator PlayCharacterAnimationAndTransition(string selectedCharacter)
    {
        if (isBoySelected) 
        {
            buttonAnimator.SetTrigger("PlayButtonAnimation");
            fadeAnimator.SetTrigger("StartFade");
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("1JeremyPov");

        }
        else if (isGirlSelected)
        {
            characterAnimator.SetTrigger("PlayCharacterAnimation");
            fadeAnimator.SetTrigger("StartFade");
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("LillyPOV1");

        }
        PlayerPrefs.SetString("SelectedCharacter", selectedCharacter);
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;

        if (fadePanel != null)
        {
            fadePanel.gameObject.SetActive(true);
        }

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadePanel.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        fadePanel.alpha = 1f;
        menuAudio.Stop();
    }
}
