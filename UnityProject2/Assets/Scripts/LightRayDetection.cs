using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRayDetection : MonoBehaviour
{
    public GameObject character;
    public ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    void onEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        int triggered = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if (triggered > 0)
        {
            character.transform.position += new Vector3(0, 20, 0);
        }
    }
}
