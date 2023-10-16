using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine;
public class TubeDestroyer : MonoBehaviour
{
    private void Awake()
    {
        EventManager.NewGame += DestroyOnRespawn;
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
        EventManager.NewGame -= DestroyOnRespawn;
    }

    private void DestroyOnRespawn()
    {
        Destroy(gameObject);
    }
}
