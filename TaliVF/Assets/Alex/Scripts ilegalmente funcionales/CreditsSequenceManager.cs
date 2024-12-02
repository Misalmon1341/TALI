using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CreditsSequenceManager : MonoBehaviour
{
    public GameObject containerPanel; 
    public GameObject[] panels; 
    public float firstPanelDuration = 8f; 
    public float panelDisplayDuration = 6f; 
    public GameObject finalPanel; 
    public float finalPanelDuration = 11f; 

    void Start()
    {
        StartCoroutine(DisplayPanelsInSequence());
    }

    private IEnumerator DisplayPanelsInSequence()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        
        if (finalPanel != null)
        {
            finalPanel.SetActive(false);
        }

        if (containerPanel != null)
        {
            containerPanel.SetActive(true); 
        }

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(true);

            if (i == 0) 
            {
                yield return new WaitForSeconds(firstPanelDuration);
                panels[i].SetActive(false);
                
                if (containerPanel != null) 
                {
                    containerPanel.SetActive(false);
                }
            }
            else
            {
                yield return new WaitForSeconds(panelDisplayDuration);
                panels[i].SetActive(false);
            }
        }

        if (finalPanel != null)
        {
            finalPanel.SetActive(true);
            yield return new WaitForSeconds(finalPanelDuration); 
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}