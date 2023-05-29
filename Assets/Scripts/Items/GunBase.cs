using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : ItemBase
{
    [SerializeField] protected int defaultAmmo;
    [SerializeField] protected int gunLevel;
    [SerializeField] protected int magazineAmmoLimit;
    [SerializeField] protected int magazineLimit;
    public GunSO gun;

}
