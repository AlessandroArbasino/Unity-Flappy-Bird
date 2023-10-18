using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PlayerStandingsDataPool 
{
    public List<PlayerStandingData> playersStanding;

    public PlayerStandingsDataPool()
    {
        playersStanding = new List<PlayerStandingData>();
    }

    public List<PlayerStandingData> OrderedPlayerStandings()
    {
         return playersStanding.OrderByDescending(x => x.score).ToList();
    }
}
