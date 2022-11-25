using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : TriggerLight
{
    bool insideRange = false;
    void Start(){
        crystal = transform.GetChild(0).gameObject;
        base.Start();
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.Equals(hands))//if it collides with the player
        {
            if (!hands.GetComponentInChildren<PickUpItems>().hasItem)
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
            toggleLight();
        }
        spinCrystal();
    }
}
