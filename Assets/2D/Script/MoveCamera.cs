using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public float offsetCamera;
    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+offsetCamera,transform.position.y,transform.position.z); 
    }
}
