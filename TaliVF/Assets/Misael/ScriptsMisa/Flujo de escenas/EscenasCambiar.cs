using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class EscenasCambiar : MonoBehaviour
{
    /* int sceneIndex;

     private void Start()
     {
         sceneIndex = SceneManager.sceneCountInBuildSettings;
     }



     // Update is called once per frame
     void Update()
     {
         if (DialogManger.dialogueTurnsQueue.Count == 0)
         {
             SceneManager.LoadScene(sceneIndex + 1);
         }
     }*/
    
    //public AudioSource clip2;
    public void EscenaAuido()
    {
        SceneManager.LoadScene("AudioController");
    }
    public void CambiarEscena1()
    {
        SceneManager.LoadScene("Misael");
    }

    public void CambiarEscena2()
    {
        //StartCoroutine(Delay());
        SceneManager.LoadScene("LilyPov2");
    }
    public void CambiarEscena3()
    {
        //StartCoroutine(Delay());
        SceneManager.LoadScene("LilyPov3");
    }
    public void CambiarEscena4()
    {
        //StartCoroutine(Delay());
        SceneManager.LoadScene("LilyPov4");
    }
    public void CambiarEscena5()
    {
        //StartCoroutine(Delay());
        SceneManager.LoadScene("LilyPov5");
    }

    /*IEnumerator Delay()

    {
        clip2.Play();
        while (clip2.isPlaying)
        {
          yield return null;
        }   
    }*/

}
