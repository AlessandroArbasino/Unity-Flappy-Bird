using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnExplosion : MonoBehaviour
{
    private void Awake()
    {
        EventManager.NewGame += DestroyOnRespawn;
    }
  
    private void DestroyOnRespawn()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.NewGame -= DestroyOnRespawn;
    }

}
