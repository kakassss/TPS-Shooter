using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] GameObject InventoryUI;
    private bool isOpen = true;

    private void Update()
    {
        ToggleInventoryUI();
    }

    private void ToggleInventoryUI()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.SetActive(isOpen);
            isOpen = !isOpen;
        }
    }

}
