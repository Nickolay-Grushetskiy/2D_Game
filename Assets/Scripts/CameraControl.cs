using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = new Vector3(player.position.x + 375, 0, -100);
    }
}
