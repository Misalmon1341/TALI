using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviorJ : MonoBehaviour
{
    public GameObject cardPanel; 
    public Image cardImage; 
    public Text cardText; 
    public Sprite cardSprite; 
    [TextArea] public string description; 
    private bool isFound = false;
    public CanvasGroup backgroundCanvasGroup;
    public static bool isCardOpen = false;


    public void OpenCard()
    {
        if (!isFound)
        {
            isFound = true;
            isCardOpen = true;

            if (cardPanel != null)
            {
                cardPanel.SetActive(true); 
                cardImage.sprite = cardSprite; 
                cardText.text = description; 
            }
            if (backgroundCanvasGroup != null)
            {
                backgroundCanvasGroup.interactable = false; 
                backgroundCanvasGroup.blocksRaycasts = false; 
            }
            FindObjectOfType<CardGameManagerJ>().CardFound();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cardPanel != null && cardPanel.activeSelf)
        {
            cardPanel.SetActive(false); 
        }
        if (backgroundCanvasGroup != null)
        {
            backgroundCanvasGroup.interactable = true; 
            backgroundCanvasGroup.blocksRaycasts = true; 
        }
        isCardOpen = false;
    }
}