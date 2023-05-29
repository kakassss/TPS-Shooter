using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();    
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Ground")
        {
            playerController.canJump = true;
        }
        
    }
}
