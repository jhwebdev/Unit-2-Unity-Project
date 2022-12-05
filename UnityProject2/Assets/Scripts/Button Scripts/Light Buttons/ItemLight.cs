using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLight : TriggerLight
{

    new void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);

        if(takeCrystal(col)){
            isEnabled = true;
            toggleLight();
            
        }
        else{
            isEnabled = false;
            toggleLight();
        }
    }
}

