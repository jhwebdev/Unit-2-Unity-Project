using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : TriggerLight
{
    new void Start(){
        crystal = transform.GetChild(0).gameObject;
        base.Start();
    }

    new void Update(){
        if(base.isClicked()){
            base.toggleLight();
            isEnabled = !isEnabled;
        }
        base.Update();
    }
}
