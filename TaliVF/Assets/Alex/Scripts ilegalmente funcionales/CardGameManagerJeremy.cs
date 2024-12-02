using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardGameManagerJeremy : MonoBehaviour
{
    public GameObject continueButton; 
    public Text progressText; 
    private int totalCards = 1; 
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
        SceneManager.LoadScene("9JeremyPov");
    }
}
