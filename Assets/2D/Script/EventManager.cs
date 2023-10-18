using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
    public static event Action Move;
    public static void OnMove() => Move?.Invoke();

    public static event Action Death;
    public static void OnDeath() => Death?.Invoke();

    public static event Action PointScored;
    public static void OnPointScored() => PointScored?.Invoke();

    public static event Action<int> DifficultyCheck;
    public static void OnDifficuiltyCheck(int points) => DifficultyCheck?.Invoke(points);

    public static event Action NewGame;
    public static void OnNewGame() => NewGame?.Invoke();

    public static event Action<string> SubmitName;
    public static void OnSubmitName(string name) => SubmitName?.Invoke(name);

    public static event Action ActivateNewGame;
    public static void OnActivateNewGame() => ActivateNewGame?.Invoke();

    public static event Action GameStarted;
    public static void OnGameStarted() => GameStarted?.Invoke();

    public static event Action<DifficultyData> ChangeDifficulty;
    public static void OnChangeDifficulty(DifficultyData currentDifficulty) => ChangeDifficulty?.Invoke(currentDifficulty);
}
