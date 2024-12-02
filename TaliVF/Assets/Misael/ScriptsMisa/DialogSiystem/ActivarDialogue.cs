using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public DialogueRound dialogue;

     void Start()
    {
        DialogManger.Instance.StartDialogue(dialogue);
    }

    public void ActiveeDialog()
    {
        DialogManger.Instance.StartDialogue(dialogue);
    }
}
