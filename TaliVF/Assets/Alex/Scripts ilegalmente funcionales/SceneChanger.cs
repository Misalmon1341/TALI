using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChangere(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }
    
     public void QuitGame()
    {
        Application.Quit();
    }
}
