 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : MonoBehaviour
{
    public GameObject prism;
    public bool multiSwitch;//if this switch is responsible for multiple lights.
    [HideInInspector]public GameObject crystal;
    [HideInInspector]public GameObject particles;
    [HideInInspector]public Light pLight;
    [HideInInspector]public GameObject hands;

    public void Start(){
        hands = GameObject.Find("Hands");

        //getting the relevant objects
        if(!multiSwitch){
            particles = prism.transform.GetChild(0).gameObject;
            pLight = prism.transform.GetChild(2).gameObject.GetComponent<Light>();
        }
        
    }

    public void toggleLight(){
        if(!multiSwitch){
            singleToggle();
        }
        else{
            multiToggle();
        }
    }
    public void multiToggle(){//to turn multiple lights on/off
        int numLights = prism.transform.childCount;

        for(int i = 0; i < numLights; i++){
            GameObject childPrism = prism.transform.GetChild(i).gameObject;//gets the specific prism inside the gameObject

            //gets relevant objects of that child
            particles = childPrism.transform.GetChild(0).gameObject;
            pLight = childPrism.transform.GetChild(2).gameObject.GetComponent<Light>();

            singleToggle();
        }
    }
    public void singleToggle()//turns light on/off
    {
        int particlesNum = particles.transform.childCount;

        for (int i = 0; i < particlesNum; i++)//runs through the index for each child
        {
            ParticleSystem pSystem = particles.transform.GetChild(i).GetComponent<ParticleSystem>();//Gets the particle system of each child

            if(pLight.enabled)
            {
                pSystem.Stop();//stops then clears particles (duhh)
                pSystem.Clear();
            }
            else if (!pLight.enabled)
            {
                pSystem.Play();
            }
        }
        
        pLight.enabled = !pLight.enabled;//switches state of the light
    }

    [HideInInspector]public float degSpin;
    public void spinCrystal(bool normal = false){//to spin the crystal, can be flipped using the bool parameter
        if(pLight != null && pLight.enabled == normal){
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
