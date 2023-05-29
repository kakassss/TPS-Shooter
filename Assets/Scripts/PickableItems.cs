using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickableItems : MonoBehaviour
{
    private const string playerTag = "Player";

    public static Action OnItemInteractionEnter;
    public static Action<GameObject> OnItemInteractionStay; 
    public static Action OnItemInteractionExit;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            OnItemInteractionEnter?.Invoke();
            OnItemInteractionStay?.Invoke(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            OnItemInteractionStay?.Invoke(gameObject);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            OnItemInteractionExit?.Invoke();
        }
    } 

}
