using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    public static MainMenu1 instance;
    public AudioSource menuAudio;
    public float fadeDuration = 3f; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (menuAudio != null)
        {
            menuAudio.volume = 0; 
            menuAudio.Play();
            StartCoroutine(FadeInAudio());
        }
    }

    void Update()
    {
        if (menuAudio.isPlaying && SceneManager.GetActiveScene().name == "CharacterSelectionScene")
        {
            menuAudio.Stop();
        }
        if (menuAudio.isPlaying && SceneManager.GetActiveScene().name == "CreditsScene")
        {
            menuAudio.Stop();
        }
       else if (menuAudio.isPlaying && SceneManager.GetActiveScene().name == "1JeremyPov") 
        {
            menuAudio.Stop();
            Destroy(gameObject);
        }
        else if(menuAudio.isPlaying && SceneManager.GetActiveScene().name == "LillyPOV1") 
        {
            menuAudio.Stop();
            Destroy(gameObject);
        }
    }

    private IEnumerator FadeInAudio()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            menuAudio.volume = Mathf.Clamp01(elapsedTime / fadeDuration); 
            yield return null;
        }

        menuAudio.volume = 1f; 
    }

    public void PlayAudio()
    {
        if (menuAudio != null && !menuAudio.isPlaying)
        {
            menuAudio.Play();
        }
    }

    public void StopAudio()
    {
        if (menuAudio != null && menuAudio.isPlaying)
        {
            menuAudio.Stop();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (menuAudio != null && scene.name == "MainMenuScene")
        {
            if (!menuAudio.isPlaying)
            {
                menuAudio.Play();
                StartCoroutine(FadeInAudio());
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}