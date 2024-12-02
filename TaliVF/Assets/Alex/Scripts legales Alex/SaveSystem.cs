using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static void SaveGame(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            return gameData;
        }
        else 
        {
            Debug.LogWarning("No se encontro un archivo de guardado.");
            return null;
        }
    }
}
public class GameManager : MonoBehaviour
{
    public void SavedGame()
    {
        int currentChapter = 1;
        string currentScene = "SceneName";
        string currentDialogue = "Ultimo dialogo mostrado";
        List<string> playerChoices = new List<string>()
        {
            "Choice1", "Choice2"
        };
        GameData gameData = new GameData(currentChapter, currentScene, currentDialogue, playerChoices);
        SaveSystem.SaveGame(gameData);
    }
    public void LoadGame()
    {
        GameData loadedData = SaveSystem.LoadGame();
        if(loadedData != null)
        {
            Debug.Log("Juego cargado en el capitulo:" + loadedData.chapter);
            Debug.Log("Escena actual:" + loadedData.sceneName);
            Debug.Log("Ultimo dialogo:" + loadedData.lastDialogue);
        }
    }
}

