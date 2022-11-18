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
                    itemPickup.GetComponent<Rigidbody>().isKinematic = true;   
                    itemPickup.transform.position = hands.transform.position; 
                    itemPickup.transform.parent = hands.transform;
                    hasItem = true;
                }
                else
                {
                    itemPickup.GetComponent<Rigidbody>().isKinematic = false;
                    itemPickup.transform.parent = null;
                    hasItem = false;
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
}
