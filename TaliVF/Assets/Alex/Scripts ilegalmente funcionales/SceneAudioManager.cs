using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneAudio
{
    public List<string> sceneNames; 
    public AudioClip audioClip; 
}

public class SceneAudioManager : MonoBehaviour
{
    public AudioSource sceneAudioSource; 
    public List<SceneAudio> sceneAudios; 

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; 
        UpdateAudioForCurrentScene(); 
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAudioForCurrentScene(); 
    }

    private void UpdateAudioForCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        foreach (SceneAudio audio in sceneAudios)
        {
            if (audio.sceneNames.Contains(currentScene))
            {
                if (sceneAudioSource.clip != audio.audioClip) 
                {
                    sceneAudioSource.clip = audio.audioClip;
                    sceneAudioSource.Play();
                }
                return; 
            }
        }

        sceneAudioSource.Stop();
    }
}