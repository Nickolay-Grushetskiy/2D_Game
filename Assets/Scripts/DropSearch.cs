using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSearch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Drop")
        {
            if (gameObject.GetComponentInParent<MainCharacter>()._inventory.AddItem(otherCollider.gameObject.GetComponent<Item>()))
                Destroy(otherCollider.gameObject);
        }
    }
}
