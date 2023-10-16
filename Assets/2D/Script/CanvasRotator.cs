using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRotator : MonoBehaviour
{
    private CanvasScaler scaler;
    // Start is called before the first frame update
    void Start()
    {
        scaler= GetComponent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width < Screen.height)
        {
            scaler.matchWidthOrHeight = 0;
        }
        else
        {
            scaler.matchWidthOrHeight = 1;
        }
    }
}
