using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnExplosion : MonoBehaviour
{
    private void Awake()
    {
        NewGameButtonScript.OnNewGame += DestroyOnRespawn;
    }
  
    private void DestroyOnRespawn()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        NewGameButtonScript.OnNewGame -= DestroyOnRespawn;
    }

}
