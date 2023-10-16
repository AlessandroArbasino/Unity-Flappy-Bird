using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStandingsDataPool
{
    public List<PlayerStandingData> playersStanding;

    public PlayerStandingsDataPool()
    {
        playersStanding = new List<PlayerStandingData>();
    }
}
