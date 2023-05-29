using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //Input data
    private float horizontal;
    private float vertical;
    
    //Movement Variables
    [SerializeField] private float movementSpeed;
    [SerializeField] private float runningSpeed;
    private float InitalMovementSpeed;
    private bool isMoving = false;
    //Jump Variables
    public bool canJump;
    [SerializeField] private float jumpForce = 6f;

    //Camera Variables
    private Camera mainCamera;
    private Vector3 cameraRelativeMovement;
    private Vector3 cameraForward;
    private Vector3 cameraRight; 
    //Rotation Variables
    [SerializeField] float turnSmoothTime = 0.1f;

    //References
    [SerializeField] private GameObject playerVisual;
    private PlayerCameraController playerCamera;
    private PlayerAnimationController playerAnimationController;
    private Rigidbody rb;
    private PlayerAim playerAim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponent<PlayerCameraController>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
        playerAim = GetComponent<PlayerAim>();

        mainCamera = Camera.main;
        InitalMovementSpeed = movementSpeed;
    }

    void FixedUpdate()
    {
        Movement();
    }
    private void Update()
    {
        IsMovement();
        PlayerInput();
        BodyRotation();   
        Jump();

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = InitalMovementSpeed;
        }
    }

    private void PlayerInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        AnimationPlayer();
    }

    private void AnimationPlayer()
    {    
        playerAnimationController.IdleToRun("HorizontalRun",horizontal);  
        playerAnimationController.IdleToRun("VerticalRun",vertical);
        playerAnimationController.Jump(!canJump);
    }
    private void IsMovement()
    {
        if(horizontal < 0 || horizontal > 0 || vertical > 0  || vertical < 0 )
        {
            isMoving = true;
        } 
        else{
            isMoving = false;
        }
        
    }
    private void Movement()
    {
        cameraForward = mainCamera.transform.forward;
        cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 forwardRelativeVerticalInput = vertical * cameraForward;
        Vector3 rightRelativeHorizontalInput = horizontal * cameraRight;

        cameraRelativeMovement = (forwardRelativeVerticalInput + rightRelativeHorizontalInput) * movementSpeed;
        Running();
        cameraRelativeMovement.y = rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(cameraRelativeMovement, movementSpeed);
        rb.velocity = cameraRelativeMovement;

     }
    
    
    private void BodyRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = cameraRelativeMovement.x;
        positionToLookAt.y = 0f;
        positionToLookAt.z = cameraRelativeMovement.z;

        Quaternion currentRotation = playerVisual.transform.rotation;
                
        if(isMoving && !playerAim.IsSharpAiming && !playerAim.currentGun.canFire)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            playerVisual.transform.rotation = Quaternion.Slerp(currentRotation,targetRotation, turnSmoothTime * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(rb.velocity.x,jumpForce,rb.velocity.y),ForceMode.Impulse);
            canJump = false;
        }
    }
    
    private void Running()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runningSpeed;
        }
        
    }
}
