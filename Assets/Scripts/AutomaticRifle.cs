using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutomaticRifle : GunAction
{
    [SerializeField] GameObject playerVisual;
    
    [Header("AimCam ShootSpread")]
    [SerializeField] private float AimCamMaxshootSpread;
    [SerializeField] private float AimCamMinshootSpread;
    [Header("StandartCam ShootSpread")]
    [SerializeField] private float StandartCamMaxshootSpread;
    [SerializeField] private float StandartCamMinshootSpread;
    


    private GameObject gunVisual;
    private PlayerAim playerAim;
    private void Start()
    {
        playerAim = GetComponentInParent<PlayerAim>();
        CreateGunVisual();    
    }

    public override void CreateGunVisual()
    {
        gunVisual = Instantiate(gunVisualPrefab,projectileSpawnPoint.position,Quaternion.identity,transform);   
    }
    public override void Fire()
    {
        if(canFire && Reload(ammoCount) && Time.time > lastTimeFire + fireRate)
        {
            CreateProjectile();
            lastTimeFire = Time.time;
            ammoCount--;
        }
        
    }

    public override void CreateProjectile()
    {
        Quaternion randomShootSpreadRotation;
        if(playerAim.IsSharpAiming)
        {
            float randomXY = Random.Range(AimCamMinshootSpread,AimCamMaxshootSpread);
            randomShootSpreadRotation = Quaternion.Euler(playerAim.camAim.transform.rotation.x + randomXY,
            playerAim.camAim.transform.rotation.y + randomXY,playerAim.camAim.transform.rotation.z);

            Instantiate(projectilePrefab,projectileSpawnPoint.position,playerAim.camAim.transform.rotation * randomShootSpreadRotation);
        }
        else
        {
            float randomXY = Random.Range(StandartCamMinshootSpread,StandartCamMaxshootSpread);
            randomShootSpreadRotation = Quaternion.Euler(playerAim.camStandart.transform.rotation.x + randomXY,
            playerAim.camStandart.transform.rotation.y + randomXY,playerAim.camStandart.transform.rotation.z);

            Instantiate(projectilePrefab,projectileSpawnPoint.position,randomShootSpreadRotation * playerAim.camStandart.transform.rotation);
        }
        
    }

    public override bool Reload(int projectileAmount)
    {
        if(projectileAmount <= 0)
        {
            return false;
        }
        return true;
    }

    public override void CheckInput()
    {
        if(Input.GetMouseButton(0))
        {
            canFire = true;
            playerAim.IsSoftAiming = true;
            playerAim.SetAnimationAimLayer(1);
            Fire();
        }
        else
        {
            canFire = false;
            playerAim.IsSoftAiming = false;
            playerAim.SetAnimationAimLayer(0);
        }
    }

}
