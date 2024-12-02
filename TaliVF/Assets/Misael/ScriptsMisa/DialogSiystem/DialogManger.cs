using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DialogManger : MonoBehaviour
{
    [SerializeField] private DialogUI dialogueUI;
    [SerializeField] private DialogueTurn dialogueTurn;
    [SerializeField] private float typingSpeed = 0.03f;
    [SerializeField] private AudioSource typingAudioSource;
    public static DialogManger Instance { get; private set; }
    public static Queue<DialogueTurn> dialogueTurnsQueue;

    public bool IsDialogInProgress { get; private set; } = false;

    private SaltarPanelOpciones saltarPanelOpciones;
    private void Awake()
    {
        Instance = this;
        dialogueUI.HideDialogBox();
        saltarPanelOpciones = FindObjectOfType<SaltarPanelOpciones>();
    }

    public void StartDialogue(DialogueRound dialogue)
    {   
        if (IsDialogInProgress)
        {
            Debug.LogWarning($"Dialogo en proceso");
            return;
        }
        IsDialogInProgress = true;
        dialogueTurnsQueue = new Queue<DialogueTurn>(dialogue.DialogueTurnsList);
        StartCoroutine(DialogueCoroutine());
    }

    private IEnumerator DialogueCoroutine()
    {
        dialogueUI.ShowDialogBox();

        while (dialogueTurnsQueue.Count > 0)
        {
            var CurrentTurn = dialogueTurnsQueue.Dequeue();

            if (CurrentTurn.IsPerson1)
            {
                dialogueUI.SetCharacterInfo1(CurrentTurn.Character);
                dialogueUI.SetPersonaje2Opacity(1f);

                if (CurrentTurn.PersonajeInvisible)
                    dialogueUI.SetPersonaje1Opacity(0f);
                else
                    dialogueUI.SetPersonaje1Opacity(0.5f);
            }
            else
            {
                dialogueUI.SetCharacterInfo2(CurrentTurn.Character);
                dialogueUI.SetPersonaje1Opacity(1f);

                if (CurrentTurn.PersonajeInvisible)
                    dialogueUI.SetPersonaje2Opacity(0f);
                else
                    dialogueUI.SetPersonaje2Opacity(0.5f);
            }

            dialogueUI.SetPersonImageVisibility(!CurrentTurn.HideImagePerson1, !CurrentTurn.HideImagePerson2);

            dialogueUI.ClearDialogArea();
            dialogueUI.SetImage1(CurrentTurn.ImagePerson1);
            dialogueUI.SetImage2(CurrentTurn.ImagePerson2);
            dialogueUI.SetDialogueFont(CurrentTurn.DialogueFont);

            yield return StartCoroutine(TypeSentence(CurrentTurn));


            yield return new WaitUntil(() =>Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return));
            yield return null;
        }
        dialogueUI.HideDialogBox();
        IsDialogInProgress = false;

        if (saltarPanelOpciones != null)
        {
            saltarPanelOpciones.OnDialogEnd();
        }
        else
        {
            Debug.LogWarning("DialogFlowController no encontrado en la escena.");
        }
    }

    private IEnumerator TypeSentence(DialogueTurn dialogTurn)
    {
        var typingWaitSeconds = new WaitForSeconds(typingSpeed);

        foreach (char letter in dialogTurn.DialogueLine.ToCharArray())
        {
            dialogueUI.AppendToDialogArea(letter);
            if (!char.IsWhiteSpace(letter)) typingAudioSource.Play();
            yield return typingWaitSeconds;

        }
    }

    
}
