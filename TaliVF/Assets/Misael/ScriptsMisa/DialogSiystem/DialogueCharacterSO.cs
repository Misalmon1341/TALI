using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue Character", menuName = "Scriptable Objects/Dialogue Character")]
public class DialogueCharacterSO : ScriptableObject
{
    [Header("Character Info")]
    [SerializeField] private string characterName;
    [SerializeField] private GameObject cuadroNombre;
    public string Name => characterName;
    public GameObject Cuadro => cuadroNombre;
}
