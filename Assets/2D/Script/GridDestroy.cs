using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDestroy : MonoBehaviour
{
    private void Awake()
    {

        NewGameButtonScript.OnNewGame += RestartBack;
    }
    private void OnDestroy()
    {
        NewGameButtonScript.OnNewGame -= RestartBack;
    }

    private void RestartBack()
    {
        Destroy(gameObject);
    }
}
