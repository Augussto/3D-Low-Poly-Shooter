using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public Camera cam;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
    
    //recieve the inputs and apply them
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void StartRunning()
    {
        float currentFov = cam.fieldOfView;
        StartCoroutine(LerpFoV(currentFov + 20));
        speed += 2;
    }
    public void StopRunning()
    {
        StartCoroutine(LerpFoV(cam.fieldOfView - 20));
        speed -= 2;
    }

    IEnumerator LerpFoV(float fov)
    {
        while (Camera.main.fieldOfView != fov)
        { // while the feild of view does not equal the desired value
            if (Camera.main.fieldOfView < fov)
            { // checks if the feild of view is less than fov so it can add up
                Camera.main.fieldOfView += 0.5f;// change this to 0.5f, 0.2f, 0.1f, depending on how fast you want the zoom
            }
            else
            {
                Camera.main.fieldOfView -= 0.5f;
            }
            yield return new WaitForSeconds(0.0f);
        }
    }
}