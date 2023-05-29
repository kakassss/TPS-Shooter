using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;

public class PlayerCameraController : MonoBehaviour
{
    public Transform cameraFollow;

    [SerializeField] private float rotationPowerMouseX;
    [SerializeField] private float rotationPowerMouseY;
    private float mouseX;
    private float mouseY;


    [Header("Standart Movement")]
    [SerializeField] private int maxStandartHeight = 330;
    [SerializeField] private int minStandartHeight = 40;

    [Header("Aiming")]
    [SerializeField] private int maxAimHeight = 330;
    [SerializeField] private int minAimHeight = 40;
    
    private PlayerAim playerAim;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerAim = GetComponent<PlayerAim>();
    }
    private void Update()
    {
        MouseInput();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CameraMoveLeftRight();
        CameraMoveUpDown();
        ClampRotationAndBlockCrossMove();
    }
    
    private void MouseInput()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void CameraMoveLeftRight()
    {     
        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseX * rotationPowerMouseX,Vector3.up);       
    }

    private void CameraMoveUpDown()
    {   
        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseY * rotationPowerMouseY,Vector3.right);
    }

    private void ClampRotationAndBlockCrossMove()
    {
        var angles = cameraFollow.transform.localEulerAngles;
        angles.z = 0;

        var angleX = cameraFollow.transform.localEulerAngles.x;
        var angleY = cameraFollow.transform.localEulerAngles.y;


        if(!playerAim.IsSharpAiming)
        {
            ClampRotationAngles(angles,angleX,maxStandartHeight,minStandartHeight);
        }
        else
        {
            ClampRotationAngles(angles,angleX,maxAimHeight,minAimHeight);
        }
    }

    private void ClampRotationAngles(Vector3 angles,float angleX, int maxHeight, int minHeight)
    {
        if(angleX > 180 && angleX < maxHeight)
        {
            angles.x = maxHeight;
        }
        else if(angleX < 180 && angleX > minHeight)
        {
            angles.x = minHeight;
        }
        cameraFollow.transform.localEulerAngles = angles;
    }
}
