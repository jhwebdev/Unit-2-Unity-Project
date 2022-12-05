using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformToggle : InteractObject
{
    public GameObject platform;

    new void Start(){
        crystal = transform.GetChild(0).gameObject;
        base.Start();
    }
    
    new void Update(){
        if(base.isClicked()){
            Debug.Log("yo");
            isEnabled = !isEnabled;
            platform.transform.GetChild(0).GetComponent<MovingObjectScript>().toggleMove();
        }
        base.Update();
    }
}
