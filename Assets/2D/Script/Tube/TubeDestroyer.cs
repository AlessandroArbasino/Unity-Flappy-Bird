using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine;
public class TubeDestroyer : MonoBehaviour
{
    private void Awake()
    {
        NewGameButtonScript.OnNewGame += DestroyOnRespawn;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "TubeDestroyer")
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        NewGameButtonScript.OnNewGame -= DestroyOnRespawn;
    }

    private void DestroyOnRespawn()
    {
        Destroy(gameObject);
    }
}
