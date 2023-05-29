using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerItemInteraction : MonoBehaviour
{
    [SerializeField] PlayerItemInteractionUI InteractionUI;
    [SerializeField] PlayerInventory Inventory; 
    private GameObject tempItem;


    public static Action<GameObject> OnItemPickUpReturnGO;
    public static Action OnItemPickUp;
    private void OnEnable()
    {
        PickableItems.OnItemInteractionStay += CheckPlayerCanLoot;
    }

    private void OnDisable()
    {
        PickableItems.OnItemInteractionStay -= CheckPlayerCanLoot;    
    }
    private void CheckPlayerCanLoot(GameObject item)
    {
        if(!Inventory.AnyInventoryGridIsEmpty())
        {
            InteractionUI.SetText(InteractionUI.inventoryFullText);      
        }

        if(Input.GetKey(KeyCode.E) && Inventory.AnyInventoryGridIsEmpty())
        {
            PickUpItem(item);
        }
    }

    private void PickUpItem(GameObject item)
    {
        if(item.TryGetComponent<ItemBase>(out var newItem)) 
        {
            tempItem = newItem.gameObject;
            OnItemPickUpReturnGO?.Invoke(tempItem);
            OnItemPickUp?.Invoke();
            PickableItems.OnItemInteractionExit?.Invoke();

            //Debug.Log("collected item name" + tempItem.name);
        }

    }

}
