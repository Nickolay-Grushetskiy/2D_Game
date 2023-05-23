using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemList : MonoBehaviour
{
    public List<ParamDropItem> dropItemList = new();
    
    public void Add(string name,int chance,int minAmount,int maxAmount)
    {
        dropItemList.Add(new ParamDropItem(name, chance, minAmount, maxAmount));
    }

    public class ParamDropItem
    {
        public string name;
        public int chance;
        public int minAmount;
        public int maxAmount;
        public ParamDropItem(string name, int chance, int minAmount, int maxAmount)
        {
            this.name = name;
            this.chance = chance;
            this.minAmount = minAmount;
            this.maxAmount = maxAmount;
        }
    }
}
