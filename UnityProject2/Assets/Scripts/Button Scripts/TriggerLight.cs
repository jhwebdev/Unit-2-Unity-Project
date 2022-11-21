 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : MonoBehaviour
{
    public GameObject particles;
    public Light light;
    public GameObject character;

    void Start()
    {
        character = GameObject.Find("Player");
    }

    public void toggleLight()//turns light on/off
    {
        int particlesNum = particles.transform.childCount;

        for (int i = 0; i < particlesNum; i++)//runs through the index for each child
        {
            ParticleSystem pSystem = particles.transform.GetChild(i).GetComponent<ParticleSystem>();//Gets the particle system of each child

            if(light.enabled)
            {
                pSystem.Stop();//stops then clears particles (duhh)
                pSystem.Clear();
            }
            else if (!light.enabled)
            {
                pSystem.Play();
            }
        }

        light.enabled = !light.enabled;//switches state of the light
    }


}
