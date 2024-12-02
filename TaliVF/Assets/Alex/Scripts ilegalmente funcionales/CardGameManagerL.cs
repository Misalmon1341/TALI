using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardGameManagerL : MonoBehaviour
{
    public GameObject continueButton; 
    public Text progressText; 
    private int totalCards = 4; 
    private int cardsFound = 0; 

    void Start()
    {
        if (continueButton != null)
            continueButton.SetActive(false); 
        
        UpdateProgressText(); 
    }

    public void CardFound()
    {
        cardsFound++; 
        UpdateProgressText(); 

        if (cardsFound >= totalCards && continueButton != null)
        {
            progressText.text = "Cartas encontradas"; 
            continueButton.SetActive(true); 
        }
    }

    private void UpdateProgressText()
    {
        if (progressText != null)
        {
            progressText.text = $"Cartas encontradas: {cardsFound}/{totalCards}"; 
        }
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("LilyPov4.3"); 
    }
}
