using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        EventManager.NewGame += NewGame;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        NewGame();
    }
    public void StartGameMethod()
    {
        EventManager.OnGameStarted();
    }

    private void NewGame()
    {
        animator.SetTrigger("GameStarted");
    }
}
