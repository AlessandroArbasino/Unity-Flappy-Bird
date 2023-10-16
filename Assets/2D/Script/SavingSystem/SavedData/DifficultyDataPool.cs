using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DifficultyDataPool
{
    public List<DifficultyData> difficultyDatas;

    public DifficultyDataPool()
    {
        difficultyDatas = new List<DifficultyData>();
    }
}
