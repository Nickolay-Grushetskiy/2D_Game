using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_helm : Item
{

    void Start()
    {
        itemName = "MilitaryHelmet";
        sprite = transform.GetComponent<SpriteRenderer>().sprite;
    }


    void Update()
    {
        
    }
}
