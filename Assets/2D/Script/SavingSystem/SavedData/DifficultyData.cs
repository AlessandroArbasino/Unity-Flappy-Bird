using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DifficultyData
{
    public string name;
    public int beginningScore;

    public int tubeOffestMax;
    public int tubeOffestMin;

    public int tubeHeightMax;
    public int tubeHeightMin;

    public int tubeSeparationMax;
    public int tubeSeparationMin;

    public float maxSpeed;

    public float musicSpeed;
}
