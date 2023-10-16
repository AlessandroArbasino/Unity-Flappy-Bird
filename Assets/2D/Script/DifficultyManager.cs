using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DifficultyValues
{
    public Difficulties difficult;

    public int tubeOffestMax;
    public int tubeOffestMin;

    public int tubeHeightMax;
    public int tubeHeightMin;

    public int tubeSeparationMax;
    public int tubeSeparationMin;

    public float maxSpeed;

    [Range(0,1)]
    public float musicSpeed;
}
public class DifficultyManager : MonoBehaviour
{
    public int points;

    public List<DifficultyValues> difficultyValuesList;
    private void Awake()
    {
        UI.OnDifficuiltyCheck += CheckDifficulty;
    }

    private void Start()
    {
        EventManager.OnChangeDifficulty(difficultyValuesList[(int)Difficulties.EASY]);
    }

    private void OnDestroy()
    {
        UI.OnDifficuiltyCheck -= CheckDifficulty;
    }

    void CheckDifficulty(int points)
    {
        
        switch (points)
        {
            case 0:
                EventManager.OnChangeDifficulty(difficultyValuesList[(int)Difficulties.EASY]);
                break;
            case 10:
                EventManager.OnChangeDifficulty(difficultyValuesList[(int)Difficulties.MEDIUM]);
                break;
            case 20:
                EventManager.OnChangeDifficulty(difficultyValuesList[(int)Difficulties.MEDIUM]);
                break;
            default: 
                break;
        }
    }
}

