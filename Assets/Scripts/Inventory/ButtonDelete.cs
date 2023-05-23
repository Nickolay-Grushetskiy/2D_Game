using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDelete : MonoBehaviour
{
    public void Activate()
    {
        gameObject.SetActive(gameObject.activeSelf ? false : true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
