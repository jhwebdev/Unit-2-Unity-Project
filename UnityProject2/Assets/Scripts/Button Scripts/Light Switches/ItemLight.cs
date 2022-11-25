using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLight : TriggerLight
{
    public string color;
    public bool hasCrystal;

    void Update(){
        spinCrystal();
    }
    void OnTriggerStay(Collider col)
    {
        Debug.Log(crystal);
        if(!hasCrystal){// if we do not have a crystal
            if(col.gameObject.tag == "Item" && col.gameObject.GetComponentInChildren<ItemScript>().isCrystal && col.gameObject.GetComponentInChildren<ItemScript>().color == color && col.gameObject.transform.parent == null)
            {     
                crystal = col.gameObject;

                crystal.GetComponent<Rigidbody>().isKinematic = true;
                crystal.transform.position = transform.position;
                crystal.transform.parent = transform;
                hasCrystal = true;

                crystal.transform.rotation = new Quaternion(0,0,0,0);//reset rotation
                crystal.transform.position += new Vector3(0, -0.3f, 0);
                toggleLight();
            }
        }
        else if(hasCrystal){
            if(transform.childCount == 0){//if player takes the crystal
                hasCrystal = false;
                crystal = null;
                toggleLight();
            }    
        }
    }
}
