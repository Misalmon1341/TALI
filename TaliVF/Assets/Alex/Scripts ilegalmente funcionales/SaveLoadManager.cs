using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public AudioSource menuAudio;
    public Image slot1Image;
    public Image slot2Image;
    public Sprite jeremySprite;
    public Sprite lilySprite;
    public Text slot1SceneText;
    public Text slot1DateText;
    public Text slot1CharacterText;
    public Text slot2SceneText;
    public Text slot2DateText;
    public Text slot2CharacterText;
    public Text messageText;  

    public void SaveGame(int saveSlot)
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        string currentScene = SceneManager.GetActiveScene().name;
        string saveDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        PlayerPrefs.SetString("SaveSlot_" + saveSlot + "_Character", selectedCharacter);
        PlayerPrefs.SetString("SaveSlot_" + saveSlot + "_Scene", currentScene);
        PlayerPrefs.SetString("SaveSlot_" + saveSlot + "_Date", saveDate);
        PlayerPrefs.SetInt("SaveSlot_" + saveSlot + "_Progress", GetCurrentGameProgress());

        PlayerPrefs.Save();
        ShowMessage("Juego guardado en la ranura: " + saveSlot);
        UpdateSlotUI(saveSlot, selectedCharacter, currentScene, saveDate);
    }

    public void LoadGame(int saveSlot)
    {
        if (PlayerPrefs.HasKey("SaveSlot_" + saveSlot + "_Progress"))
        {
            int progress = PlayerPrefs.GetInt("SaveSlot_" + saveSlot + "_Progress");
            LoadGameProgress(progress);

            string selectedCharacter = PlayerPrefs.GetString("SaveSlot_" + saveSlot + "_Character");
            string currentScene = PlayerPrefs.GetString("SaveSlot_" + saveSlot + "_Scene");
            string saveDate = PlayerPrefs.GetString("SaveSlot_" + saveSlot + "_Date");

            ShowMessage("Juego cargado con el personaje: " + selectedCharacter + " en la escena: " + currentScene + " guardado en: " + saveDate);
        }
        else
        {
            ShowMessage("No hay datos guardados en la ranura: " + saveSlot);
        }
    }

    private void UpdateSlotUI(int slot, string character, string scene, string date)
    {
        if (slot == 1)
        {
            slot1Image.sprite = character == "Jeremy" ? jeremySprite : lilySprite;
            slot1SceneText.text = scene;
            slot1DateText.text = date;
            slot1CharacterText.text = character;
        }
        else if (slot == 2)
        {
            slot2Image.sprite = character == "Jeremy" ? jeremySprite : lilySprite;
            slot2SceneText.text = scene;
            slot2DateText.text = date;
            slot2CharacterText.text = character;
        }
    }

    private int GetCurrentGameProgress()
    {
        return 1;
    }

    private void LoadGameProgress(int progress)
    {
        ShowMessage("Progreso cargado: " + progress);
    }

    private void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        StartCoroutine(HideMessageAfterDelay());
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        messageText.gameObject.SetActive(false);
    }

    void Start()
    {
        LoadSlotData(1);
        LoadSlotData(2);
        messageText.gameObject.SetActive(false);  
        slot1DateText.gameObject.SetActive(false);
        slot1CharacterText.gameObject.SetActive(false);
        slot1SceneText.gameObject.SetActive(false);
        slot2SceneText.gameObject.SetActive(false);
        slot2CharacterText.gameObject.SetActive(false);
        slot2DateText.gameObject.SetActive(false);
    }

    private void LoadSlotData(int slot)
    {
        if (PlayerPrefs.HasKey("SaveSlot_" + slot + "_Character"))
        {
            string character = PlayerPrefs.GetString("SaveSlot_" + slot + "_Character");
            string scene = PlayerPrefs.GetString("SaveSlot_" + slot + "_Scene");
            string date = PlayerPrefs.GetString("SaveSlot_" + slot + "_Date");
            UpdateSlotUI(slot, character, scene, date);
        }
    }
}
