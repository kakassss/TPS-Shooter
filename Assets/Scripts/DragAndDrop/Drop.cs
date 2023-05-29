using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        var otherItem = eventData.pointerDrag.GetComponentInChildren<Draggable>();
        var otherItemGO = otherItem.gameObject;

        var localItem = GetComponentInChildren<Draggable>();
        var localItemGO = localItem.gameObject;

        if( otherItem.itemBase != null) 
        {
            localItemGO.GetComponent<Image>().sprite = otherItemGO.GetComponent<Image>().sprite;
            localItem.itemBase = otherItem.itemBase;    
            localItemGO.transform.position = transform.position;
         
        }
    }

    
}
