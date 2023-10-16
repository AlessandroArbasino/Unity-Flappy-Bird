using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
	private Animator  controller;

    private void Awake()
    {
        EventManager.GameStarted += StartAnimating;
        EventManager.Death += RestartAnimationPossibility;
    }
    void Start()
	{
		controller = GetComponent<Animator>();
	}

    private void OnDestroy()
    {
        EventManager.Move -= Animate;
        EventManager.GameStarted -= StartAnimating;
    }

    void Animate()
    {
		controller.SetTrigger("New Trigger");
    }

    private void StartAnimating()
    {
        EventManager.Move += Animate;
    }

    private void RestartAnimationPossibility()
    {
        EventManager.Move -= Animate;
    }
}
