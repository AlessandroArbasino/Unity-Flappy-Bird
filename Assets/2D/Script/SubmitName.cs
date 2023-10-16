using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitName : MonoBehaviour
{
    [SerializeField]
    private InputField playerNameField;
    [SerializeField]
    private Button submitButton;

    public static event Action<string> OnSubmitName;
    public static event Action OnActivateNewGame;
    public void SubmitNameMethod()
    {
        OnSubmitName?.Invoke(playerNameField.text);
        OnActivateNewGame?.Invoke();

        submitButton.interactable = false;
    }

    private void OnEnable()
    {
        submitButton.interactable = true;    
    }
}
