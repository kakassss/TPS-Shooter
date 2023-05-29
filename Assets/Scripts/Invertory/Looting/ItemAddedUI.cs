using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemAddedUI : MonoBehaviour
{
    private readonly string addedItem = "Item added to inventory";
    [SerializeField] GameObject ItemLabel;

    public Queue<GameObject> itemLabelQueue;
    public List<GameObject> itemLabelList;
    private Coroutine itemQueue;
    private void OnEnable()
    {
        itemLabelQueue = new();
        itemLabelList = new();
        PlayerItemInteraction.OnItemPickUpReturnGO += CreateUILabelContainer;
    }

    private void OnDisable()
    {
        PlayerItemInteraction.OnItemPickUpReturnGO -= CreateUILabelContainer;
    }

    private void Update()
    {
        itemLabelList.RemoveAll(x => x == null);

        if(itemLabelList.Count >= 4)
        {
            if(itemLabelQueue == null) return;

           itemQueue = StartCoroutine(CreateQueueItems());
        }
        else
        {
            if(itemQueue != null)
                StopCoroutine(itemQueue);
        }    
    }
    private void CreateUILabelContainer(GameObject item)
    {
        CreateItemLabel(item);
    }

    private void CreateItemLabel(GameObject item)
    {
        if(itemLabelList.Count >= 4)
        {
            GameObject newItemLabel1 = Instantiate(ItemLabel,transform);
            var newItem1 = item.GetComponent<ItemBase>();
            var itemText1 = newItemLabel1.GetComponentInChildren<TextMeshProUGUI>();
            itemText1.text = newItem1.itemName + " " + addedItem;
            itemLabelQueue.Enqueue(newItemLabel1);
            newItemLabel1.SetActive(false);
        }
        else
        {
            GameObject newItemLabel = Instantiate(ItemLabel,transform);
            var newItem = item.GetComponent<ItemBase>();
            var itemText = newItemLabel.GetComponentInChildren<TextMeshProUGUI>();
            itemText.text = newItem.itemName + " " + addedItem;
            itemLabelList.Add(newItemLabel);
            newItemLabel.SetActive(true);
            ItemLabelMove();
        }
        
    }
    private IEnumerator CreateQueueItems()
    {
        yield return new WaitUntil(() => itemLabelList.Count < 4);
        if(itemLabelQueue == null) yield break;
        if(itemLabelQueue.TryPeek(out GameObject newItem))
        {
            newItem = itemLabelQueue.Dequeue();
            itemLabelList.Add(newItem);
            newItem.SetActive(true);
             
            ItemLabelMove();
            if(itemLabelQueue == null) yield break;
        }
        
    }

    private void ItemLabelMove()
    {
        if(itemLabelList == null && itemLabelQueue == null)
            return;

        for (int i = 0; i < itemLabelList.Count; i++)
        {
            itemLabelList[i].transform.position = Vector3.Lerp(itemLabelList[i].transform.position,
            itemLabelList[i].transform.position + new Vector3(0,80,0), 120 * Time.deltaTime);
        }
    }

    
    
}
