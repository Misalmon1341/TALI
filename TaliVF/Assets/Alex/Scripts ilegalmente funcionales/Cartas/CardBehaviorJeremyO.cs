using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviorJeremyO: MonoBehaviour
{
    public GameObject cardPanel; 
    public Image cardImage; 
    public Text cardText; 
    public Sprite cardSprite; 
    [TextArea] public string description; 
    private bool isFound = false; 

    public void OpenCard()
    {
        if (!isFound)
        {
            isFound = true;

            if (cardPanel != null)
            {
                cardPanel.SetActive(true); 
                cardImage.sprite = cardSprite; 
                cardText.text = description; 
            }
            FindObjectOfType<CardGameManagerJeremy>().CardFound();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cardPanel != null && cardPanel.activeSelf)
        {
            cardPanel.SetActive(false); 
        }
    }
}