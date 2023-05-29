using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ProjectileBaseAction : MonoBehaviour
{
    
    [SerializeField] protected TrailRenderer trailRenderer; 
    [SerializeField] protected ParticleSystem bulletHitVFX;
    [SerializeField] protected float projetileSpeed;
    [SerializeField] protected float destroyTime;
    [SerializeField] protected float damage;
    
    public abstract void ProjectileMovement();
    public abstract void ProjectileDestroy();
    public abstract void InsantiateTrail();
    public abstract void InstantiateVFX();
    
}
