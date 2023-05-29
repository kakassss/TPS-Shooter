using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItemInteractionUI : MonoBehaviour
{
    private readonly string collectText = "Press 'E' to pick up";
    [HideInInspector] public readonly string inventoryFullText = "Inventory Full";
    [SerializeField] TextMeshProUGUI collectItemText;
    

    private void OnEnable()
    {   
        collectItemText.gameObject.SetActive(false);

        SetText(collectText);

        PickableItems.OnItemInteractionEnter += EnableText;   
        PickableItems.OnItemInteractionExit += DisableText; 
    }
    public void SetText(string text)
    {
        collectItemText.text = text;
    }
    private void OnDisable()
    {
        PickableItems.OnItemInteractionEnter -= EnableText;
        PickableItems.OnItemInteractionExit -= DisableText;    
    }

    private void EnableText()
    {
        collectItemText.gameObject.SetActive(true);
    }

    private void DisableText()
    {
        collectItemText.gameObject.SetActive(false);
    }
}
