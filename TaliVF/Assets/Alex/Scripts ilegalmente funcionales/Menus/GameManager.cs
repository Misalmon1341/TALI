using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    private string selectedCharacter;

    void Start()
    {
        selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");

        if (selectedCharacter == "Boy")
        {
            Debug.Log("Personaje seleccionado: Jeremy");
        }
        else if (selectedCharacter == "Girl")
        {
            Debug.Log("Personaje seleccionado: Lily");
        }
    }
}