using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;


public struct PlayerData : IComparable<PlayerData>
{
    public string Name;
    public int Points { get; set; }

    public PlayerData(string name,int points)
    {
        Name = name; 
        Points = points;
    }

    public int CompareTo(PlayerData previousPlayerData)
    {
        return  previousPlayerData.Points- Points;
    }
}
public class Standings : MonoBehaviour
{
    public GameObject standingTile;

    public int maxStandingSize;

    public Text playerPoints;
    private void Awake()
    {
        EventManager.Death += LoadStandings;
        EventManager.SubmitName += SetTile;
    }
    private void OnDestroy()
    {
        EventManager.Death -= LoadStandings;
        EventManager.SubmitName -= SetTile;
    }

    public void SetTile(string playerName)
    {
        List<PlayerData> standingLoad = new List<PlayerData>();
        if (PlayerPrefs.HasKey("Standing"))
            standingLoad = JsonConvert.DeserializeObject<List<PlayerData>>(PlayerPrefs.GetString("Standing"));

        PlayerPrefs.DeleteKey("Standing");

        PlayerData tilePlayerData = new PlayerData(playerName, int.Parse(playerPoints.text));
        standingLoad.Add(tilePlayerData);
        standingLoad.Sort();

        if (standingLoad.Count>= maxStandingSize)
        {
            standingLoad.RemoveAt(maxStandingSize-1);
        }

        PlayerPrefs.SetString("Standing", JsonConvert.SerializeObject(standingLoad));
        LoadStandings();
    }

    private void LoadStandings()
    {
        List<PlayerData> standing = new List<PlayerData>();
        if (PlayerPrefs.HasKey("Standing"))
            standing = JsonConvert.DeserializeObject<List<PlayerData>>(PlayerPrefs.GetString("Standing"));

        DestroyInstanzatedTiles();

        foreach (PlayerData playerData in standing)
        {
            GameObject tileInstance = Instantiate<GameObject>(standingTile, gameObject.transform);
            tileInstance.GetComponent<LoadTile>().LoadTileMethod(standing.LastIndexOf(playerData)+1, playerData.Name, playerData.Points);
        }
    }

    public void DeleteStanding()
    {
        PlayerPrefs.DeleteKey("Standing");
        DestroyInstanzatedTiles();
    }

    private void DestroyInstanzatedTiles()
    {
        foreach (LoadTile tile in GetComponentsInChildren<LoadTile>())
        {
            Destroy(tile.gameObject);
        }
    }
}
