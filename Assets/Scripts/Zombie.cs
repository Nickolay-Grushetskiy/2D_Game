using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public override void AddDropItems()
    {
        _dropItemList.Add("5.45x39", 100, 10, 50);
        _dropItemList.Add("MilitaryHelmet", 100, 1, 1);
    }

    void Start()
    {
        AddDropItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
