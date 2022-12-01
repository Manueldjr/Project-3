using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class bombExplosion : MonoBehaviour
{
    [SerializeField] private VisualEffect sparkParticles;
    public AudioSource bombSound;


    public float  expForce, Radius;

    private void Awake()
    {
        sparkParticles.Stop();
        bombSound.Stop();
    }

    
   
    public void StartExplosion()
    {
        //Debug.Log("Explosion");
        sparkParticles.Play();
        bombSound.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if(rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, Radius);
            }
        }

    }
}
