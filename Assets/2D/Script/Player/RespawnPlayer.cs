using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private Vector3 inititalPosition;

    private void Awake()
    {
        NewGameButtonScript.OnNewGame += ReSpawnPosition;
    }
    void Start()
    {
        inititalPosition = transform.position;
    }

    private void OnDestroy()
    {
        NewGameButtonScript.OnNewGame -= ReSpawnPosition;
    }

    // Update is called once per frame
    private void ReSpawnPosition()
    {
        gameObject.SetActive(true);
        transform.position = inititalPosition;
    }

    
}
