using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    protected bool canCollectable;
    public int itemCount;
    public string itemName;
    public Sprite itemImage;
    public GameObject itemGameObject;
}
