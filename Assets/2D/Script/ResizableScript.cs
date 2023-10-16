using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizableScript : MonoBehaviour
{
    private RectTransform trasformRect;

    void Start()
    {
        trasformRect= GetComponent<RectTransform>();
    }
    void Update()
    {
        if(Screen.width<Screen.height) 
        {
            trasformRect.offsetMin = new Vector2(-300, 451);
            trasformRect.offsetMax = new Vector2(300, -451);
        }
        else
        {
            trasformRect.offsetMin = new Vector2(-300, 100);
            trasformRect.offsetMax = new Vector2(300, -100);
        }
    }
}
