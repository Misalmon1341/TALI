using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalAudioManager : MonoBehaviour
{
    public static GlobalAudioManager Instance;
    public AudioSource globalAudioSource;
    public string[] scenesToMute;
    private bool isManuallyPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (globalAudioSource == null)
        {
            Debug.LogError("AudioSource no asignado en GlobalAudioManager.");
            return;
        }

        UpdateAudioState();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAudioState();
    }

    private void UpdateAudioState()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (System.Array.Exists(scenesToMute, sceneName => sceneName == currentScene))
        {
            if (globalAudioSource.isPlaying)
            {
                globalAudioSource.Pause();
                isManuallyPaused = true;
            }
        }
        else
        {
            if (!globalAudioSource.isPlaying || isManuallyPaused)
            {
                isManuallyPaused = false;
                globalAudioSource.Play();
            }
        }
    }

    public void PauseGlobalAudio()
    {
        if (globalAudioSource != null && globalAudioSource.isPlaying)
        {
            globalAudioSource.Pause();
            isManuallyPaused = true;
        }
    }

    public void UnPauseGlobalAudio()
    {
        if (globalAudioSource != null && !globalAudioSource.isPlaying)
        {
            globalAudioSource.Play();
            isManuallyPaused = false;
        }
    }

    public void StopGlobalAudio()
    {
        if (globalAudioSource != null && globalAudioSource.isPlaying)
        {
            globalAudioSource.Stop();
            isManuallyPaused = true;
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;

        if (GlobalAudioManager.Instance != null && GlobalAudioManager.Instance.globalAudioSource != null)
        {
            GlobalAudioManager.Instance.globalAudioSource.Pause();
            isManuallyPaused = true;
        }

        SceneManager.LoadScene("MainMenuScene");
    }
}