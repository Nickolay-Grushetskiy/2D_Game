using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public Dictionary<string,int> items = new (); //<name item, path to prefab>
    [SerializeField] public List<GameObject> prefabs = new();
    
    void Start()
    {
        items.Add("5.45x39", 0);
        items.Add("MilitaryHelmet", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
