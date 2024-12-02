using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public static CursorChanger instance;
   public enum CursorStates
    {
       busqueda,
        carta, 
        otravez
    }
    public CursorStates estadoCursor = CursorStates.busqueda;
    public Texture2D[] cursores;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Cursor.visible = true;
        Cursor.SetCursor(cursores[(int)estadoCursor], Vector2.zero, CursorMode.Auto);
    }

    public void CambiarCursor(CursorStates estado)
    {
        Cursor.SetCursor(cursores[(int)estado], Vector2.zero, CursorMode.Auto);
    }

}
