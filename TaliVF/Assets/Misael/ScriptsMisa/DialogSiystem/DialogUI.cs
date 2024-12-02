using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;


public class DialogUI : MonoBehaviour
{

    [SerializeField][Tooltip("Dialogo que se va amostrar en pantalla")] private RectTransform dialogBox;

    [Header("Personaje 1")]
    [SerializeField] private Image personaje1Cuadro;
    [SerializeField] private TextMeshProUGUI personaje1Texto;

    [Header("Personaje 2")]
    [SerializeField] private Image personaje2Cuadro;
    [SerializeField] private TextMeshProUGUI personaje2Texto;

    [SerializeField] private Image Personaje1;
    [SerializeField] private Image Personaje2;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogArea;

    public void SetDialogueFont(TMP_FontAsset font)
    {
        if (font != null)
        {
            dialogArea.font = font;
        }
        else
        {
            Debug.Log("Fuente no asignada en el turno de diálogo.");
        }
    }
    public void ShowDialogBox()
    {
        dialogBox.gameObject.SetActive(true);
    }

    public void HideDialogBox()
    {
        dialogBox.gameObject.SetActive(false);
    }

    public void SetCharacterInfo1(DialogueCharacterSO character)
    {
        if (character == null) return;
        HidePerson2();
        ShowPerson1();
        personaje1Texto.text = character.Name;
    }
    public void SetCharacterInfo2(DialogueCharacterSO character)
    {
        if (character == null) return;
        HidePerson1();
        ShowPerson2();
        personaje2Texto.text = character.Name;
    }

    public void HideCharacterInfo(DialogueCharacterSO character)
    {
        if (character == null) return;
    }
    

    public void ClearDialogArea()
    {
        dialogArea.text = string.Empty;
    }
    public void SetDialogArea(string text)
    {
        dialogArea.text = text;
      
    }
    public void SetImage1(Sprite personaje1)
    {
        Personaje1.sprite = personaje1;
    }
    public void SetImage2(Sprite personaje2)
    {
        Personaje2.sprite = personaje2;
    }

    public void AppendToDialogArea(char letter)
    {
        dialogArea.text += letter;
    }

    public void ShowPerson1()
    {
        personaje1Cuadro.gameObject.SetActive(true);
        personaje1Texto.gameObject.SetActive(true);
    }

    public void HidePerson1()
    {
        personaje1Cuadro.gameObject.SetActive(false);
        personaje1Texto.gameObject.SetActive(false);
    }

    // Métodos para activar y desactivar Personaje 2
    public void ShowPerson2()
    {
        personaje2Cuadro.gameObject.SetActive(true);
        personaje2Texto.gameObject.SetActive(true);
    }

    public void HidePerson2()
    {
        personaje2Cuadro.gameObject.SetActive(false);
        personaje2Texto.gameObject.SetActive(false);
    }

    public void SetPersonaje1Opacity(float alpha)
    {
        SetImageOpacity(Personaje1, alpha);
    }

    public void SetPersonaje2Opacity(float alpha)
    {
        SetImageOpacity(Personaje2, alpha);
    }

    public void SetImageOpacity(Image image, float alpha)
    {
        if (image == null) return;

        Color color = image.color;
        color.a = Mathf.Clamp01(alpha);
        image.color = color;
    }

    public void SetPersonImageVisibility(bool showPerson1, bool showPerson2)
    {
        Personaje1.gameObject.SetActive(showPerson1);
        Personaje2.gameObject.SetActive(showPerson2);
    }

}
