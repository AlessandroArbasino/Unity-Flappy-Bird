using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTile : MonoBehaviour
{
    public Text playerPositionText;
    public Text playerNameText;
    public Text playerScoreText;

    private void Awake()
    {
        EventManager.NewGame += DestroyTile;
    }
    public void LoadTileMethod(int playerPosition,string playerName, int playerScore)
    {
        playerPositionText.text = playerPosition.ToString();
        playerNameText.text = playerName;
        playerScoreText.text = playerScore.ToString();
    }

    public void DestroyTile()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.NewGame -= DestroyTile;
    }
}
