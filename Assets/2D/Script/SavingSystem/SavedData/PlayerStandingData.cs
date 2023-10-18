using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStandingData
{
    public string nickname;
    public int score;

    public PlayerStandingData(string nickname, int score)
    {
        this.nickname = nickname;
        this.score = score;
    }
}
