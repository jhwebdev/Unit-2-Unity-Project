using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    GameObject itemPickup;
    bool canPickup = false;
    public bool hasItem = false;

    void Update()
    {
        if(canPickup)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!hasItem)
                {
                    pickUpItem(itemPickup);
                }
                else
                {
                    dropItem(itemPickup);
                }
            }
            
        }
    }

    void OnTriggerStay(Collider item)
    {
        if(item.gameObject.tag == "Item" && !hasItem)
        {

            canPickup = true;
            itemPickup = item.gameObject;
        }
    }

    void OnTriggerExit(Collider item)
    {
        if (!hasItem) {canPickup = false;}
    }

    public void dropItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        hasItem = false;
    }

    public void pickUpItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = transform.position;
        item.transform.parent = transform;
        hasItem = true;
    }
}
