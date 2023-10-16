using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDestroyOnRespawn : MonoBehaviour
{
    private void Awake()
    {
        EventManager.NewGame += DestroyOnRespawn;
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
