using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
	private Animator  controller;

    private void Awake()
    {
        StartGame.OnGameStarted += StartAnimating;
        PlayerMovement.OnDeath += RestartAnimationPossibility;
    }
    void Start()
	{
		controller = GetComponent<Animator>();
	}

    private void OnDestroy()
    {
		PlayerMovement.OnMove -= Animate;
        StartGame.OnGameStarted -= StartAnimating;
    }

    void Animate()
    {
		controller.SetTrigger("New Trigger");
    }

    private void StartAnimating()
    {
        PlayerMovement.OnMove += Animate;
    }

    private void RestartAnimationPossibility()
    {
        PlayerMovement.OnMove -= Animate;
    }
}
