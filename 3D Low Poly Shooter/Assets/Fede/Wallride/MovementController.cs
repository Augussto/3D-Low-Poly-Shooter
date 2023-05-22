using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;

    public Transform groundCheck;

    public LayerMask groundMask;
    public LayerMask wallMask;

    private Vector3 input;
    private Vector3 move;
    private Vector3 Yvelocity;
    private Vector3 fowardDirection;

    private float speed;
    public float runSpeed;
    public float airSpeed;

    private bool isSprinting;
    public float sprintSpeed;

    private bool isCrouching;
    public float crouchSpeed;

    private float gravity;
    public float normalGravity;

    private float startHeight;
    private float crouchHeight = 0.5f;
    private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    private Vector3 standingCenter = new Vector3(0, 0, 0);

    private bool isGrounded;
    private int jumpChanges;
    public float jumpHeight;

    private bool isSliding;
    private float slideTimer;
    public float maxSlideTimer;
    public float slideSpeedIncrease;
    public float slideSpeedDecreased;

    private bool isWallRunning, hasWallRun= false;
    private float wallRunGravity, wallRunSpeedIncrease, wallRunSpeedDecrease;
    private bool onLeftWall, onRightWall;
    private RaycastHit leftWallHit, rightWallHit;
    private Vector3 wallNormal, lastWallNormal;//direcciones contrarias a la pared

    public Camera playerCamera;
    private float normalFov;
    public float specialFov;
    public float cameraChangeTime;
    public float wallRunTilt;
    public float tilt;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startHeight = transform.localScale.y;
        normalFov = playerCamera.fieldOfView; // toma el fov de base como el normal
    }

    void Update()
    {
        HandleInput();
        CheckWallRun();
        
        if (isGrounded && !isSliding)
        {
            GroundedMovement();
        }
        else if (!isGrounded && !isWallRunning)
        {
            AirMovement();
        }
        else if (isWallRunning)
        {
            WallRunMovement();
            DecreaseSpeed(wallRunSpeedDecrease);
        }
        else if (isSliding)
        {
            SlideMovement();
            DecreaseSpeed(slideSpeedDecreased);
            slideTimer -= 1f * Time.deltaTime;
            if (slideTimer <= 0)
            {
                isSliding = false;
            }
            
        }
        
        controller.Move(move * Time.deltaTime);
        ApplyGravity();
        CameraEffects();
    }
    
    void FixedUpdate()
    {
        CheckGround();
    }

    void CameraEffects()
    {
        float fov = isWallRunning ? specialFov : isSliding ? specialFov : normalFov;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, fov, cameraChangeTime * Time.deltaTime);

        if (isWallRunning)
        {
            if (onRightWall)
            {
                tilt = Mathf.Lerp(tilt, wallRunTilt, cameraChangeTime * Time.deltaTime);
            }
            else if (onLeftWall)
            {
                tilt = Mathf.Lerp(tilt, -wallRunTilt, cameraChangeTime * Time.deltaTime);
            }
        }
        else
        {
            tilt = Mathf.Lerp(tilt, 0f, cameraChangeTime * Time.deltaTime);
        }

    }
    
    void HandleInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxis("Vertical"));

        input = transform.TransformDirection(input);
        input = Vector3.ClampMagnitude(input, 1f);

        if (Input.GetKeyDown(KeyCode.Space) && jumpChanges > 0)
        {
            Jump();
            jumpChanges = 0;
        }

        if (Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            Crouch();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            ExitCrouch();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
    }

    void GroundedMovement()
    {
        speed = isSprinting ? sprintSpeed : isCrouching ? crouchSpeed : runSpeed;
        
        if (input.x !=0)
        {
            move.x += input.x * speed;
        }
        else
        {
            move.x = 0;
        }
        
        if (input.z !=0)
        {
            move.z += input.z * speed;
        }
        else
        {
            move.z = 0;
        }

        move = Vector3.ClampMagnitude(move, speed);
    }
    
    void AirMovement()
    {
        move.x += input.x * airSpeed;
        move.z += input.z * airSpeed;
    
        move = Vector3.ClampMagnitude(move, speed);
    }

    void SlideMovement()
    {
        move += fowardDirection;
        move = Vector3.ClampMagnitude(move, speed);

    }

    void Jump()
    {
        if (!isGrounded && !isWallRunning)
        {
            jumpChanges -= 1;
        }
        else if(isWallRunning)
        {
            ExitWallRun();
            IncreaseSpeed(wallRunSpeedIncrease);
        }
        Yvelocity.y = Mathf.Sqrt(jumpHeight * -2f * normalGravity);
    }

    void Crouch()
    {
        controller.height = crouchHeight;
        controller.center = crouchingCenter;
        transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
        if (speed > runSpeed)
        {
            isSliding = true;
            fowardDirection = transform.forward;
            if (isGrounded)
            {
                IncreaseSpeed(slideSpeedIncrease);
            }
            slideTimer = maxSlideTimer;
        }
        isCrouching = true;
    }

    void ExitCrouch()
    {
        controller.height = (startHeight * 2);
        controller.center = standingCenter;
        transform.localScale = new Vector3(transform.localScale.x, startHeight, transform.localScale.z);
        isCrouching = false;
        isSliding = false;
    }
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
        if (isGrounded)
        {
            jumpChanges = 1;
            hasWallRun = false;
        }
    }
    void IncreaseSpeed(float speedIncrease)
    {
        speed += speedIncrease;
    }

    void DecreaseSpeed(float speedDecrease)
    {
        speed -= speedDecrease * Time.deltaTime;
    }
    
    void ApplyGravity()
    {
        gravity = isWallRunning ? wallRunGravity : normalGravity;
        Yvelocity.y += gravity * Time.deltaTime;
        controller.Move(Yvelocity * Time.deltaTime);
    }
    
    //wallraid functions
    
    void CheckWallRun()
    {
        onLeftWall = Physics.Raycast(transform.position, -transform.right, out leftWallHit, 0.7f, wallMask);
        onRightWall = Physics.Raycast(transform.position, transform.right, out rightWallHit, 0.7f, wallMask);

        if ((onRightWall || onLeftWall)&& !isWallRunning)
        {
            TestWallRun();
        }

        if ((!onRightWall || !onLeftWall)&& isWallRunning)
        {
            ExitWallRun();
        }
    }

    void TestWallRun()
    {
        wallNormal = onRightWall ? rightWallHit.normal : leftWallHit.normal;
        if (hasWallRun)
        {
            float wallAngle = Vector3.Angle(wallNormal, lastWallNormal);
            if (wallAngle > 15)
            {
                WallRun();
            }
        }
        else
        {
            WallRun();
            hasWallRun = true;
        }
    }
    void WallRun()
    {
        isWallRunning = true;
        jumpChanges = 1;
        IncreaseSpeed(wallRunSpeedIncrease);
        Yvelocity = new Vector3(0f, 0f, 0f);

        
        fowardDirection = Vector3.Cross(wallNormal, Vector3.up);

        if (Vector3.Dot(fowardDirection,transform.forward)< 0)
        {
            fowardDirection = -fowardDirection;
        }
    }
    
    void WallRunMovement()
    {
        if (input.z > (fowardDirection.z - 10f) && input.z < (fowardDirection.z + 10f))
        {
            move.z += fowardDirection.z;
        }
        else if (input.z > (fowardDirection.z - 10f) && input.z > (fowardDirection.z + 10f))
        {
            move.z = 0f;
            move.x = 0f;
            ExitWallRun();
        }

        move.x += input.x * airSpeed;

        move = Vector3.ClampMagnitude(move, speed);
    }   
    void ExitWallRun()
    {
        isWallRunning = false;
        lastWallNormal = wallNormal;
    }
    
}