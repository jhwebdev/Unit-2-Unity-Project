 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{
    public GameObject particles;
    public Light light;

    void OnTriggerEnter(Collider col)
    {
        int particlesNum = particles.transform.childCount;
        light.enabled = false;

        for(int i=0;i<particlesNum;i++)//runs through the index for each child
        {
            ParticleSystem pSystem = particles.transform.GetChild(i).GetComponent<ParticleSystem>();//Gets the particle system of each child
            pSystem.Stop();//stops then clears particles (duhh)
            pSystem.Clear();
        }  
    }
}
