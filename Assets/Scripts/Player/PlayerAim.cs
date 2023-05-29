using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Rig aimRig;
    [SerializeField] PlayerAnimationController playerAnimation;
    [SerializeField] GameObject playerVisual;
    [SerializeField] float turnSmoothTime;
    public bool IsSharpAiming = false;
    public bool IsSoftAiming = false;

    public GameObject camAim;
    public GameObject camStandart;
 
    public GunAction currentGun;
    private void Start()
    {
        currentGun = GetComponentInChildren<GunAction>();
        camStandart.SetActive(true);
        camAim.SetActive(false);    
    }
    private void FixedUpdate()
    {
        CheckIsAiming();
    }
    private void Update()
    {
        StartAiming();    
        currentGun.CheckInput();
    }
    private void StartAiming()
    {
        if(Input.GetMouseButton(1))
        {
            IsSharpAiming = true;
            IsSoftAiming = false;
            camStandart.SetActive(false);
            //SetAnimationAimLayer(1);
            //playerAnimation.animator.SetLayerWeight(1,Mathf.Lerp(playerAnimation.animator.GetLayerWeight(1),1f,Time.deltaTime * 10));
            
            camAim.SetActive(true);
            //aimRig.weight = Mathf.Lerp(aimRig.weight,1,Time.deltaTime * 20f);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            IsSharpAiming = false;

            camStandart.SetActive(true);
            //SetAnimationAimLayer(0);
            //playerAnimation.animator.SetLayerWeight(1,Mathf.Lerp(playerAnimation.animator.GetLayerWeight(1),0f,Time.deltaTime * 10));
            
            camAim.SetActive(false);
            //aimRig.weight = Mathf.Lerp(aimRig.weight,0,Time.deltaTime * 20f);
        }

        if(IsSharpAiming || IsSoftAiming)
        {
            aimRig.weight = Mathf.Lerp(aimRig.weight,1,Time.deltaTime * 20f);
        }
        else
        {
            aimRig.weight = Mathf.Lerp(aimRig.weight,0,Time.deltaTime * 20f);
        }
        

        
    }

    public void SetAnimationAimLayer(int weight)
    {
        playerAnimation.animator.SetLayerWeight(1,Mathf.Lerp(playerAnimation.animator.GetLayerWeight(1),weight,Time.deltaTime * 10));
    }

    private void CheckIsAiming()
    {
        if(IsSharpAiming == true)
        {
            CameraRelevantMovement_WhileAiming();
            playerAnimation.animator.SetLayerWeight(2,Mathf.Lerp(playerAnimation.animator.GetLayerWeight(2),1f,Time.deltaTime * 10));
        }
        if(!IsSharpAiming && currentGun.canFire)
        {
            playerAnimation.animator.SetLayerWeight(2,Mathf.Lerp(playerAnimation.animator.GetLayerWeight(2),0f,Time.deltaTime * 10));
            CameraRelevantMovement_WhileAiming();
        }
        
    }
    private void CameraRelevantMovement_WhileAiming()
    {
        Vector3 cameraLook;

        cameraLook.x = Camera.main.transform.forward.x;
        cameraLook.y = 0f;
        cameraLook.z = Camera.main.transform.forward.z;

        Quaternion currentRotation = playerVisual.transform.rotation;

        
        Quaternion targetRotation = Quaternion.LookRotation(cameraLook);
        playerVisual.transform.rotation = Quaternion.Slerp(currentRotation,targetRotation, turnSmoothTime * Time.deltaTime);

    }

    


}
