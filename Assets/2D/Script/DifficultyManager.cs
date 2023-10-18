using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour,ISaveable
{
    public int points;

    private List<DifficultyData> difficultiesDatas;
    private void Awake()
    {
        UI.OnDifficuiltyCheck += CheckDifficulty;
    }

    private void Start()
    {
        EventManager.OnChangeDifficulty(difficultiesDatas[0]);
    }

    private void OnDestroy()
    {
        UI.OnDifficuiltyCheck -= CheckDifficulty;
    }

    void CheckDifficulty(int points)
    {
        
        //switch (points)
        //{
        //    case 0:
        //        EventManager.OnChangeDifficulty(difficultyValuesList[(int)Difficulties.EASY]);
        //        break;
        //    case 10:
        //        EventManager.OnChangeDifficulty(difficultyValuesList[(int)Difficulties.MEDIUM]);
        //        break;
        //    case 20:
        //        EventManager.OnChangeDifficulty(difficultyValuesList[(int)Difficulties.MEDIUM]);
        //        break;
        //    default: 
        //        break;
        //}

        foreach(DifficultyData data in difficultiesDatas)
        {
            if (points == data.beginningScore)
            {
                EventManager.OnChangeDifficulty(data);
                break;
            }
        }
    }

    public void LoadData(SaveData data)
    {
        difficultiesDatas = data.gameData.difficultyDataPool.difficultyDatas;
    }

    public void SaveData(ref SaveData data)
    {
        
    }
}

