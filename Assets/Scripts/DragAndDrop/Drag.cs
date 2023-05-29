using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image mainImage;
    [HideInInspector] public Vector3 InitPos;
    [SerializeField] Draggable draggable;

    private void Start()
    {
        InitPos = transform.position;    
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if(draggable.itemBase == null) return;

        mainImage.raycastTarget = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(draggable.itemBase == null) return;

        mainImage.transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(draggable.itemBase == null) return;

        
        if(eventData.pointerEnter  ==  null)
        {
            mainImage.transform.position = transform.parent.position;
            mainImage.raycastTarget = true;
            return;
        }
        
        if(GetComponentInParent<BottomBarItem>())  
        {
            if(eventData.pointerEnter.GetComponentInParent<BottomBarItem>().isEmpty)
            {
                mainImage.transform.position = transform.parent.position;
                mainImage.raycastTarget = true;
                draggable.itemBase = null;
                mainImage.sprite = null; 
                GetComponentInParent<BottomBarItem>().isEmpty = true;
                eventData.pointerEnter.GetComponentInParent<BottomBarItem>().isEmpty = false;
            }   
            else
            {
                mainImage.transform.position = transform.parent.position;
                mainImage.raycastTarget = true;
            }
        }

        
    }

}
