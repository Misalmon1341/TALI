using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public class DialogueTurn 
{

    [field: SerializeField]
    public DialogueCharacterSO Character { get; private set; }

    [SerializeField, TextArea(2, 4)]
    private string dialogueLine = string.Empty;

    public string DialogueLine => dialogueLine;

    [SerializeField] private bool isPerson1;

    [SerializeField] private Sprite Person1;
    [SerializeField] private Sprite Person2;

    [SerializeField] private bool personajeInvisible;

    public bool PersonajeInvisible => personajeInvisible;
    public Sprite ImagePerson1 => Person1;
    public Sprite ImagePerson2 => Person2;

    public bool IsPerson1 => isPerson1;

    [SerializeField] private bool hideImagePerson1;
    [SerializeField] private bool hideImagePerson2;

    public bool HideImagePerson1 => hideImagePerson1;
    public bool HideImagePerson2 => hideImagePerson2;

    [SerializeField] private TMP_FontAsset dialogueFont;
    public TMP_FontAsset DialogueFont => dialogueFont;
}
