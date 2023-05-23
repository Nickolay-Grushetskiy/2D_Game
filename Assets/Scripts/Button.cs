using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{


    private Text textToEdit;
    void Start()
    {
        textToEdit = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Debug.Log("Fire");
    }
}
