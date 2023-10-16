using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDestroyOnRespawn : MonoBehaviour
{
    private void Awake()
    {
        NewGameButtonScript.OnNewGame += DestroyOnRespawn;
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
