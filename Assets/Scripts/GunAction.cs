using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunAction : MonoBehaviour
{
    [SerializeField] protected GameObject gunVisualPrefab;
    [SerializeField] protected Transform projectileSpawnPoint;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected int ammoCount;
    [SerializeField] protected float fireRate;
    [SerializeField] protected bool IsAutomatic;
    public bool canFire;
    protected float lastTimeFire;

    public abstract void Fire();
    public abstract bool Reload(int projectileAmount);
    public abstract void CreateProjectile();
    public abstract void CheckInput();
    public abstract void CreateGunVisual();

}
