using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public GameObject player;
    bool canPickup = false;
    bool hasItem = false;
    GameObect pickUp;

    // Update is called once per frame
    void Update()
    {
        if (canPickup)
        {

        }
    }

    void OnTriggerEnter(Collider col)
    {

    }

    void OnTriggerExit(Collider col)
    {
        canPickup = false;
    }
}
