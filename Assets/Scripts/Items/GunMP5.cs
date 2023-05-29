using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMP5 : GunBase
{
    private void Start()
    {
        GetDataFromSO();    
    }
    private void GetDataFromSO()
    {
        itemCount = gun.itemCount;
        itemName = gun.itemName;
        itemImage = gun.itemImage;
        itemGameObject = gun.itemGameobject;

        defaultAmmo = gun.defaultAmmo;
        gunLevel = gun.gunLevel;
        magazineAmmoLimit = gun.magazineAmmoLimit;
        magazineLimit = gun.magazineLimit;

    }
}
