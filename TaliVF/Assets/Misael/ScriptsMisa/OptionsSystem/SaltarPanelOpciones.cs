using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaltarPanelOpciones : MonoBehaviour
{
    public bool skipOptionsPanel;
    [SerializeField] private string nombreEscena;

    public void OnDialogEnd()
    {
        if (skipOptionsPanel)
        {
            if (!string.IsNullOrEmpty(nombreEscena))
            {
                SceneManager.LoadScene(nombreEscena);
            }
            else
            {
                Debug.LogError("El nombre de la escena no está configurado en SaltarPanelOpciones.");
            }
        }
        else
        {
            OptionsManager.Instance?.ActivarPanel();
        }
    }
}
