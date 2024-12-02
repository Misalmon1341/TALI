using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PanelPausa : MonoBehaviour
{
    public GameObject pausaPanel;
    public GameObject optionsPanel;
    public string mainMenuSceneName = "MainMenuScene"; 
    public string[] allowedScenes; 
    public string[] restrictedScenes; 

    private void Start()
    {
        pausaPanel.SetActive(false);
        optionsPanel.SetActive(false);

        CheckAndHandleSceneRestrictions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPauseAllowed())
        {
            PausaMenu();
        }
    }

    public void PausaMenu()
    {
        pausaPanel.SetActive(true);
        Time.timeScale = 0f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void Resume()
    {
        pausaPanel.SetActive(false);
        Time.timeScale = 1f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void Opciones()
    {
        pausaPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void BackToPausa()
    {
        optionsPanel.SetActive(false);
        pausaPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        pausaPanel.SetActive(false);
        Time.timeScale = 1f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }

        SceneManager.LoadScene(mainMenuSceneName);
    }

    private bool IsPauseAllowed()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        return System.Array.Exists(allowedScenes, sceneName => sceneName == currentScene) &&
               !System.Array.Exists(restrictedScenes, sceneName => sceneName == currentScene);
    }

    private void CheckAndHandleSceneRestrictions()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (System.Array.Exists(restrictedScenes, sceneName => sceneName == currentScene))
        {
            GlobalAudioManager.Instance?.PauseGlobalAudio();

            pausaPanel.SetActive(false);
        }
        else
        {
            GlobalAudioManager.Instance?.UnPauseGlobalAudio();
        }
    }
}