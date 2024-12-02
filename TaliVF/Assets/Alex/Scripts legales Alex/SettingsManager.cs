using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    
    public Text languageText;
    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("language", language);
        UpdateLanguageUI(language);
    }
    void Start()
    {
        string savedLanguage = PlayerPrefs.GetString("language", "English");
        UpdateLanguageUI(savedLanguage);
       
    }
    void UpdateLanguageUI(string language)
    {
        languageText.text = language;
    }
}
public class GraphicsSettings 
{
    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
