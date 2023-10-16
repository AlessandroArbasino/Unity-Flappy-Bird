using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackGround : MonoBehaviour
{
    public GameObject BackGround;

    private void Awake()
    {
        NewGameButtonScript.OnNewGame += CreateBackGroundMethod;
    }
    void Start()
    {
        CreateBackGroundMethod();
    }

    private void OnDestroy()
    {
        NewGameButtonScript.OnNewGame -= CreateBackGroundMethod;
    }
    private void CreateBackGroundMethod()
    {
        Instantiate<GameObject>(BackGround, transform);
    }
}
