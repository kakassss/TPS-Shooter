using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarSlot : MonoBehaviour
{
   public List<GameObject> ItemBars;

   private void Awake()
   {
      InitItemSlots();   
   }

   private void InitItemSlots()
   {
      foreach (Transform item in transform.GetChild(0))
      {
         if(item.GetComponentInChildren<BottomBarItem>())
         {
            ItemBars.Add(item.gameObject);
         }
      }
      
      SortItemNumbers();
   }

   private void SortItemNumbers()
   {
      for (int i = 0; i < ItemBars.Count; i++)
      {
         ItemBars[i].GetComponentInChildren<InventoryItemUI>().ItemSlotNumber = i + 1;
      }

      SetItemText();
   }

   private void SetItemText()
   {
      for (int i = 0; i < ItemBars.Count; i++)
      {
         ItemBars[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
      }

      SetItemEmptyState();
   }

   private void SetItemEmptyState()
   {
      for (int i = 0; i < ItemBars.Count; i++)
      {
         ItemBars[i].GetComponentInChildren<InventoryItemUI>().isEmpty = true;
      }
   }
}
