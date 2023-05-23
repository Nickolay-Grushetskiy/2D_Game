using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool active = true;
    private Slot _slotAmmo;

    void Start()
    {
        _slotAmmo = transform.GetChild(9).GetComponent<Slot>();
        gameObject.SetActive(false);
        AddAmmo(50);
    }

    public void Activate()
    {
        active = !active;
        gameObject.SetActive(active);
    }
    public void AddAmmo(int count)
    {
        _slotAmmo.count += count;
        _slotAmmo.GetComponentInChildren<Text>().text = _slotAmmo.count.ToString();
    }
    public bool GetAmmo()
    {
        if (_slotAmmo.count > 0)
        {
            _slotAmmo.count--;
            _slotAmmo.GetComponentInChildren<Text>().text = _slotAmmo.count.ToString();
            return true;
        }
        return false;
    }
    public bool AddItem(Item item)
    {
        if (item.itemName == "5.45x39")
        {
            AddAmmo(item.count);
            return true;
        }

        Slot slot;
        int freeSlot = -1;
        int i;
        for (i = 8; i >= 0; --i)
        {
            slot = transform.GetChild(i).GetComponent<Slot>();
            if (slot.text == "")
            {
                freeSlot = i;
            }
            if (slot.itemName == item.itemName)
            {
                slot.count += item.count;
                slot.SetText();
                return true;
            }
        }
        if(freeSlot<0)
            return false;
        else
        {
            slot = transform.GetChild(freeSlot).GetComponent<Slot>();
            slot.count += item.count;
            slot.itemName = item.itemName;
            slot.SetText();
            slot.SetSprite(item.sprite);
            return true;
        }
    }

    public void Remove(Item item) 
    {

    }
}

