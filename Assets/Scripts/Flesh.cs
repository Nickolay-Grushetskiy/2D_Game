using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flesh : Enemy
{
    private void Start()
    {
        AddDropItems();
        //distAttackInSqr = 3600;
    }
    public override void AddDropItems()
    {
        _dropItemList.Add("5.45x39", 100, 1, 50);
        _dropItemList.Add("MilitaryHelmet", 100, 1, 1);
    }
}
