using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public GameObject hands;
    GameObject itemPickup;
    bool canPickup = false;
    public bool hasItem = false;

    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            if (canPickup)
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

    void OnTriggerEnter(Collider item)
    {
        if(item.gameObject.tag == "Item" && !hasItem)
        {
            Debug.Log("Entered cool trueers");
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
        item.transform.position = hands.transform.position;
        item.transform.parent = hands.transform;
        hasItem = true;
    }
}
