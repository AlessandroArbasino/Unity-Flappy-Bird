using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text difficulty;
    public Text points;

    public static event Action<int> OnDifficuiltyCheck;

    private int pointsINT;

    public GameObject DeadPanel;

    private void Awake()
    {
        PlayerMovement.OnPointScored += ScorePoints;
        PlayerMovement.OnDeath += ActivateDeadUI;

        NewGameButtonScript.OnNewGame += SetRespawnUI;
        DifficultyManager.OnChangeDifficulty += UISpawn;
    }

    private void OnDestroy()
    {
        PlayerMovement.OnPointScored -= ScorePoints;
        PlayerMovement.OnDeath -= ActivateDeadUI;

        NewGameButtonScript.OnNewGame -= SetRespawnUI;
        DifficultyManager.OnChangeDifficulty -= UISpawn;
    }

    private void UISpawn(DifficultyValues values)
    {
        difficulty.text = values.difficult.ToString();
    }

    private void ScorePoints()
    {
        pointsINT++;
        points.text= pointsINT.ToString();

        OnDifficuiltyCheck?.Invoke(pointsINT);
    }

    private void ActivateDeadUI()
    {
        DeadPanel.SetActive(true);
    }

    private void SetRespawnUI()
    {
        DeadPanel.SetActive(false);

        points.text = "0";
        pointsINT = 0;
        OnDifficuiltyCheck?.Invoke(0);
    }
}
