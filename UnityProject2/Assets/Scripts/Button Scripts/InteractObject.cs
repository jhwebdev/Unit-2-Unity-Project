using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [HideInInspector]public GameObject hands;
    [HideInInspector]public GameObject player;
    public bool insideRange;
    [HideInInspector]public bool isEnabled;
    public void Start(){
        hands = GameObject.Find("Hands");
        player = GameObject.Find("Player");
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.Equals(hands))//if it collides with the player
        {
            if (!hands.GetComponentInChildren<PickUpItems>().hasItem)
            {
                insideRange = true;
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        insideRange = false;
    }

    public void Update(){
        spinCrystal();
    }
    
    [HideInInspector]public bool hasCrystal;
    public string color;
    public bool takeCrystal(Collider col){//manages taking and dropping crystal, to be called inside onTriggerStay, returns if we have a crystal slotted
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
                return hasCrystal;
            }
        }
        else if(hasCrystal){
            if(transform.childCount == 0){//if player takes the crystal
                hasCrystal = false;
                crystal = null;
                return hasCrystal;
            }    
        }
        return hasCrystal;
    }

    public bool isClicked(){//if the object is interacted with
         if (insideRange && Input.GetKeyDown("e"))
        {
            Debug.Log("yo touched me");
            return true;
        }
        return false;
    }

    [HideInInspector]public float degSpin;
    [HideInInspector]public GameObject crystal;
    public void spinCrystal(bool normal = true){//to spin the crystal, can be flipped using the bool parameter
        if(isEnabled == normal){
            degSpin = 100;
        }
        else{
            degSpin = 0;
        }
        if(crystal != null){//if crystal is defined(if we have one)
            crystal.transform.Rotate(0f, degSpin*Time.deltaTime,0f, Space.Self);
        }
    }
}
