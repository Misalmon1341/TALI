using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameData loadedData = SaveSystem.LoadGame();
        if(loadedData != null)
        {
            SceneManager.LoadScene(loadedData.sceneName);
        }
        else 
        {
            SceneManager.LoadScene("Primer capitulo");
        }
    }    
    public void OpenSettings()
    {
        GameObject settingsPanel = GameObject.Find("SettingsPanel");
        settingsPanel.SetActive(true); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
public class GameData
{
    public int chapter;           
    public string sceneName;      
    public string lastDialogue;   
    public List<string> choices;  

    public GameData(int chapter, string sceneName, string lastDialogue, List<string> choices)
    {
        this.chapter = chapter;
        this.sceneName = sceneName;
        this.lastDialogue = lastDialogue;
        this.choices = choices;
    }
}