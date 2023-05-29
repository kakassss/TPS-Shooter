using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRifleProjectile : ProjectileBaseAction
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        InsantiateTrail();    
    }

    private void Start()
    {
        ProjectileMovement();        
        ProjectileDestroy();
    }
    public override void ProjectileDestroy( )
    {
        Destroy(gameObject,destroyTime);   
    }

    public override void ProjectileMovement()
    {
        rigidbody.velocity = transform.forward * projetileSpeed;
    }

    public override void InsantiateTrail()
    {
        Instantiate(trailRenderer,transform.position,Quaternion.identity,transform);
    }

    public override void InstantiateVFX()
    {
        Destroy(gameObject,0.5f);
        ParticleSystem hitVFX = Instantiate(bulletHitVFX,transform.position,Quaternion.identity);
        //hitVFX.Play();

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            InstantiateVFX();
            
        }
         
    }
}
