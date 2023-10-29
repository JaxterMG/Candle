using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemTrigger : MonoBehaviour
{
    ParticleSystem _circleParticles;
    void Start()
    {
        _circleParticles = GetComponent<ParticleSystem>();

        InvokeRepeating("EmitParticles", 0, 2);
        
    }

    private void EmitParticles()
    {
        _circleParticles.Play();
        SoundManager.Instance.RequestSound("Call");
    }
}
