using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSiystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public string[] Lines;

    public float textSpeed = 0.1f;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == Lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                dialogueText.text = Lines[index];   
            }
        } 
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in Lines[index].ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < Lines.Length -1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine (WriteLine());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Panel"))
        {
            StartDialogue();
        }
    }*/
}
