using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaClickeable : MonoBehaviour
{
    public CursorChanger.CursorStates cursorMode;
    public GameObject objeto;

    public GameObject PanelMensaje;


    private void Start()
    {
        objeto.SetActive(false);
        PanelMensaje.SetActive(false);
    }

    private void OnMouseEnter()
    {
        CursorChanger.instance.CambiarCursor(cursorMode);
        objeto.SetActive(true);
    }
    private void OnMouseExit()
    {
        CursorChanger.instance.CambiarCursor(CursorChanger.CursorStates.busqueda);
        objeto.SetActive(false);
    }

    private void OnMouseDown()
    {
        PanelMensaje.SetActive(true);
        CursorChanger.instance.CambiarCursor(CursorChanger.CursorStates.busqueda);
    }
}
