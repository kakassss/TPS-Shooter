using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemLabelDestroy : MonoBehaviour
{
    private ItemAddedUI ItemAddedUI; 
    private IEnumerator Start()
    {
        ItemAddedUI = GetComponentInParent<ItemAddedUI>();
        yield return new WaitForSeconds(3);
        ItemAddedUI.itemLabelList.RemoveAt(0);
        Destroy(gameObject);   
    }

}
