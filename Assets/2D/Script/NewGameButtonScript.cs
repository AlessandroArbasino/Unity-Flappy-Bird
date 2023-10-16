using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButtonScript : MonoBehaviour
{
    public static event Action OnNewGame;

    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        SubmitName.OnActivateNewGame += ActivateButton;
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
        OnNewGame?.Invoke();
    }

    private void ActivateButton()
    {
        button.interactable = true;
    }
}
