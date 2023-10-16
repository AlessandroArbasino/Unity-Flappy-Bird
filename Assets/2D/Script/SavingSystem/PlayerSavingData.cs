using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UIElements;

[Serializable]
public class PlayerSavingData
{
	public PlayerStandingsDataPool playerStandingsDataPool;

	public PlayerSavingData()
	{
		SetupFirstSave();
	}

	public void SetupFirstSave()
	{
		playerStandingsDataPool = new PlayerStandingsDataPool();
	}

}

