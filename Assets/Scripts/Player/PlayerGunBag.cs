using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunBag : MonoBehaviour
{
    private readonly Vector3 gunPos = new Vector3(45,-95,-5);
    public List<GameObject> items;
    [SerializeField] private Transform playerBackGunPos;
    private GameObject currentGunVisual;
    private void OnEnable()
    {
        PlayerItemInteraction.OnItemPickUpReturnGO += GetNewGun;    
    }


    private void GetNewGun(GameObject gunGO)
    {
        //gunGO.SetActive(false);
        currentGunVisual = null;

        currentGunVisual = gunGO;
        //currentGunVisual.SetActive(false);
        items.Add(currentGunVisual);

        currentGunVisual.transform.position = playerBackGunPos.position;
        currentGunVisual.transform.parent = playerBackGunPos.transform;
        currentGunVisual.transform.localRotation *= Quaternion.Euler(gunPos.x,gunPos.y,gunPos.z);


    }
}
