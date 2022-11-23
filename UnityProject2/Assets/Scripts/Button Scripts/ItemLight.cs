using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLight : TriggerLight
{
    GameObject crystal;
    public string color;


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Item")
        {
            if (col.gameObject.GetComponentInChildren<ItemScript>().isCrystal && col.gameObject.GetComponentInChildren<ItemScript>().color == color)
            {
                crystal = col.gameObject;
                crystal.transform.parent.gameObject.GetComponent
            }
        }
    }
}
