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

    public void SubmitNameMethod()
    {
        EventManager.OnSubmitName(playerNameField.text);
        EventManager.OnActivateNewGame();

        submitButton.interactable = false;
    }

    private void OnEnable()
    {
        submitButton.interactable = true;    
    }
}
