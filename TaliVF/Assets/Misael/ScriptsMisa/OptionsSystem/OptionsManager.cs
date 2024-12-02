using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class OptionsManager : MonoBehaviour
{
    public GameObject panelOpt;
    public static OptionsManager Instance { get; private set; }

     private void Awake()
      {
          //panelOpt.SetActive(false);
          if (Instance == null)
          {
              Instance = this;
             
          }
          else 
          {
              Destroy(gameObject);            
          }
      }

    private int Index;
    void Start()
    {
        panelOpt.SetActive(false);
    }

    public void ActivarPanel()
    {
            panelOpt.SetActive(true);
    }
}
