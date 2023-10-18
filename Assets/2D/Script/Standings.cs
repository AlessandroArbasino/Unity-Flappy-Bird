using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Standings : MonoBehaviour,ISaveable
{
    [SerializeField] private GameObject standingTile;
    [SerializeField] private Text playerPoints;
    [SerializeField] private int maxStandingSize;

    private PlayerStandingsDataPool playerStandingsDataPool;
    private void Awake()
    {
        EventManager.SubmitName += SetTile;
    }
    private void OnDestroy()
    {
        EventManager.Death -= LoadStandings;
        EventManager.SubmitName -= SetTile;
    }

    public void SetTile(string playerName)
    {
        playerStandingsDataPool.playersStanding.Add(new PlayerStandingData(playerName, int.Parse(playerPoints.text)));
        LoadStandings();
    }

    private void LoadStandings()
    {
        Debug.Log("standings loaded");
        List<PlayerStandingData> standing = playerStandingsDataPool.OrderedPlayerStandings();

        DestroyInstanzatedTiles();

        int instanziatedTiles = 0;
        foreach (PlayerStandingData playerData in standing)
        {
            GameObject tileInstance = Instantiate<GameObject>(standingTile, gameObject.transform);
            tileInstance.GetComponent<LoadTile>().LoadTileMethod(standing.LastIndexOf(playerData)+1, playerData.nickname, playerData.score);
            instanziatedTiles++;

            if (instanziatedTiles >= maxStandingSize)
                break;
        }
    }

    public void DeleteStanding()
    {
        playerStandingsDataPool.playersStanding.Clear();
        DestroyInstanzatedTiles();
    }

    private void DestroyInstanzatedTiles()
    {
        foreach (LoadTile tile in GetComponentsInChildren<LoadTile>())
        {
            Destroy(tile.gameObject);
        }
    }

    public void LoadData(SaveData data)
    {
        playerStandingsDataPool = data.playerData.playerStandingsDataPool;
        EventManager.Death += LoadStandings;
    }

    public void SaveData(ref SaveData data)
    {
        data.playerData.playerStandingsDataPool.playersStanding = playerStandingsDataPool.playersStanding;
    }
}
