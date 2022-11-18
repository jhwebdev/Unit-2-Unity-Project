using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : TriggerLight
{
    private GameObject player;
    bool insideRange = false;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")//if it collides with the player
        {
            player = col.gameObject;
            if (!player.GetComponentInChildren<PickUpItems>().hasItem)
            {
                insideRange = true;
            }
            
        }
    }

    void OnTriggerExit(Collider col)
    {
        insideRange = false;
    }

    void Update()
    {
        if (insideRange && Input.GetKeyDown("e"))
        {
            Debug.Log(insideRange && Input.GetKeyDown("e"));
            toggleLight();
            
        }
        
    }
}
