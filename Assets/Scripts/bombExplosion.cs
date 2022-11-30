using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class bombExplosion : MonoBehaviour
{
    [SerializeField] private VisualEffect sparkParticles;

    private void Awake()
    {
        sparkParticles.Stop();
    
    }

    private void Update()
    {
        sparkParticles.Stop();
    }
    public void StartExplosion()
    {
        Debug.Log("Explosion");
        sparkParticles.Play();
        
        

    }
}
