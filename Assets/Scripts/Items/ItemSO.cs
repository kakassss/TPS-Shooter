using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public GameObject itemGameobject;
    public int itemCount;
    public ItemSO(string itemName, Sprite itemImage, GameObject itemGameobject,int itemCount)
    {
        this.itemImage = itemImage;
        this.itemName = itemName;
        this.itemGameobject = itemGameobject;
        this.itemCount = itemCount;
    } 
}
