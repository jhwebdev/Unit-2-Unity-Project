using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultButton : MonoBehaviour
{
    [HideInInspector]public GameObject character;
    [HideInInspector]public bool insideRange;
    [HideInInspector]public bool triggered;//if button is triggered
    
    [HideInInspector]public bool used = false;//if button has been used, for single use things
    void Start()
    {
        character = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void Update()
    {
        if (insideRange && Input.GetKeyDown("e"))
        {
            triggered = true;
            used = true;
        }
        else{
            triggered = false;
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.Equals(character))//if it collides with the player
        {
            if (!character.GetComponentInChildren<PickUpItems>().hasItem)
            {
                insideRange = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        insideRange = false;
    }
}
