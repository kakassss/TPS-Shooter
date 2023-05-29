using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> InventoryGrids;
    [SerializeField] private GameObject InventoryParent;

    public List<GameObject> InventoryItems;
    
    private void Awake()
    {
        InventoryGrids = new List<GameObject>();

        foreach (Transform item in InventoryParent.transform)
        {
            item.GetComponentInChildren<InventoryGridHolder>().isEmpty = true;
            InventoryGrids.Add(item.gameObject);    
        }   
         
        PlayerItemInteraction.OnItemPickUpReturnGO += AddItemToInventory;    
    }
    
    private void AddItemToInventory(GameObject item)
    {
        GameObject empytGrid = ReturnEmptyGrid();

        var newItem = item.GetComponent<ItemBase>(); 

        var newEmptyGrid = empytGrid.GetComponentInChildren<InventoryGridHolder>();
        var newEmptyImage = newEmptyGrid.image;
        var newEmptyTex = newEmptyGrid.text;

        string ItemName = newItem.itemName + " " + newItem.itemName;
        newEmptyTex.text = ItemName;
        newEmptyImage.sprite = newItem.itemImage;
        newEmptyGrid.isEmpty = false;
        newEmptyGrid.GetComponentInChildren<Draggable>().itemBase = newItem;

        InventoryItems.Add(item);
    }
    
    private GameObject ReturnEmptyGrid()
    {
        foreach (var item in InventoryGrids)
        {
            if(item.GetComponentInChildren<InventoryGridHolder>().isEmpty)
            {
                return item;
            } 
        }
        return null;
    }

    public bool AnyInventoryGridIsEmpty()
    {
        foreach (var item in InventoryGrids)
        {
            if(item.GetComponentInChildren<InventoryGridHolder>().isEmpty)
            {
                return true;
            } 
        }
        return false;
    }

    // public void CheckIfGridIsEmpty_MakeClear()
    // {

    // }
}
