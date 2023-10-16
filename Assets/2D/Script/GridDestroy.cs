using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDestroy : MonoBehaviour
{
    private void Awake()
    {

        EventManager.NewGame += RestartBack;
    }
    private void OnDestroy()
    {
        EventManager.NewGame -= RestartBack;
    }

    private void RestartBack()
    {
        Destroy(gameObject);
    }
}
