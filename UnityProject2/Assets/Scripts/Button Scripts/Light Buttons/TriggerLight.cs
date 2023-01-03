 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : InteractObject
{
    public GameObject prism;
    public GameObject prism2;
    public bool startOff;// if this should start off
    public bool multiSwitch;//if this switch is responsible for multiple lights that are a child of an empty
    public bool timerSwitch;//if this switch will turn on and off by itself.
    public bool dualSwitch;//if this switch is responsible for two specific lights (used in puzzles, so the same light can be referenced by different lights), does not use lights as children of empty
    [HideInInspector]public GameObject particles;
    [HideInInspector]public Light pLight;
    

    new public void Start(){
        //getting the relevant objects
        if(!multiSwitch){
            particles = prism.transform.GetChild(0).gameObject;
            pLight = prism.transform.GetChild(1).gameObject.GetComponent<Light>();
        }
        if(startOff){
            if(multiSwitch){
                multiToggle();
            }
            else if(dualSwitch){
                dualToggle();
            }
            else{
                singleToggle(); 
            }
        }
        base.Start();
    }

    new public void Update(){
        timerToggle();
        base.Update();
    }
    public void toggleLight(){
        if(multiSwitch){
            multiToggle();
        }
        else if(dualSwitch){
            dualToggle();
        }
        else{
            singleToggle(); 
        }
    }


    public void dualToggle(){
        particles = prism.transform.GetChild(0).gameObject;
        pLight = prism.transform.GetChild(1).gameObject.GetComponent<Light>();

        singleToggle();
        
        particles = prism2.transform.GetChild(0).gameObject;
        pLight = prism2.transform.GetChild(1).gameObject.GetComponent<Light>();

        singleToggle();
    }

    public void multiToggle(){//to turn multiple lights on/off
        int numLights = prism.transform.childCount;
        
        for(int i = 0; i < numLights; i++){
            GameObject childPrism = prism.transform.GetChild(i).gameObject;//gets the specific prism inside the gameObject

            //gets relevant objects of that child
            particles = childPrism.transform.GetChild(0).gameObject;
            pLight = childPrism.transform.GetChild(1).gameObject.GetComponent<Light>();

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

    public float time = 1;//to set offset between different lights
    public int timer = 10;//how long between on/off states
    public void timerToggle(){
        if(!timerSwitch){return;}

        time += Time.deltaTime;

        if((int)time % timer == 0){
            toggleLight();
            time += 1;
        }
    }
}
