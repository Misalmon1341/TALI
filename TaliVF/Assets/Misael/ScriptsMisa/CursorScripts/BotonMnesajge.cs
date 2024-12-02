using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMnesajge : MonoBehaviour
{
    
    public void Continuar()
    {
        SceneManager.LoadScene("Misael2");
    }

   /*public void Retroceder()
    {
        ZonaClickeable.PanelMensaje.SetActive(false);
    }*/
}
