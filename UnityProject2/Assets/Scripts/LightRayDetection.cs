using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRayDetection : MonoBehaviour
{
    GameObject player;
    public ParticleSystem ps;
    int triggered;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    void Start()
    {
        player = GameObject.Find("Player");
        
    }    void onEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other){
        
        if(other.tag == "Player"){
            player.GetComponent<ThirdPersonMovement>().hit = true;
        }
    }
}
