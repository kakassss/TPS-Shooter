using UnityEngine;

[CreateAssetMenu(fileName = "GunSO", menuName = "ScriptableObjects/GunSo", order = 1)]
public class GunSO : ItemSO
{
    //[SerializeField] private int maxAmmoCount;// 180 projectile
    public int defaultAmmo;
    public int gunLevel;
    public int magazineAmmoLimit; //can carry 30 projectiles 
    public int magazineLimit; // can carry max 3 magazine

    public GunSO(string itemName, Sprite itemImage,GameObject itemGameobject,int itemCount,int defaultAmmo,int gunLevel, int magazineAmmoLimit, int magazineLimit)
    : base(itemName, itemImage, itemGameobject,itemCount)
    {
        this.itemImage = itemImage;
        this.itemName = itemName;
        this.itemGameobject = itemGameobject;
        this.itemCount = itemCount;
        this.defaultAmmo = defaultAmmo;
        this.gunLevel = gunLevel;
        this.magazineAmmoLimit = magazineAmmoLimit;
        this.magazineLimit = magazineLimit;
    }


}
