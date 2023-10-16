using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private Animator animator;

    public static event Action OnGameStarted;

    private void Awake()
    {
        NewGameButtonScript.OnNewGame += NewGame;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        NewGame();
    }
    public void StartGameMethod()
    {
        OnGameStarted?.Invoke();
    }

    private void NewGame()
    {
        animator.SetTrigger("GameStarted");
    }
}
