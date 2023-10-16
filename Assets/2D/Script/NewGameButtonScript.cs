using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButtonScript : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        EventManager.ActivateNewGame += ActivateButton;
    }
    void Start()
    {
        button.onClick.AddListener(delegate { NewGame(); });
    }

    private void OnEnable()
    {
        button.interactable = false;
    }

    private void NewGame()
    {
        EventManager.OnNewGame();
    }

    private void ActivateButton()
    {
        button.interactable = true;
    }
}
