using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackGround : MonoBehaviour
{
    public GameObject BackGround;

    private void Awake()
    {
        EventManager.NewGame += CreateBackGroundMethod;
    }
    void Start()
    {
        CreateBackGroundMethod();
    }

    private void OnDestroy()
    {
        EventManager.NewGame -= CreateBackGroundMethod;
    }
    private void CreateBackGroundMethod()
    {
        Instantiate<GameObject>(BackGround, transform);
    }
}
