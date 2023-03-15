using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PrincipalCharacterInputActions playerInputActions;
    private PrincipalCharacterInputActions.PlayerActions playerActions;

    private PlayerMotor motor;
    private PlayerLook look;

    private void Awake()
    {
        playerInputActions = new PrincipalCharacterInputActions();
        playerActions = playerInputActions.Player;
        motor = GetComponent<PlayerMotor>();
        //Everytime the player press "jump" it use a ctx(call back context) to call the jump function
        playerActions.Jump.performed += ctx => motor.Jump();
        look = GetComponent<PlayerLook>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    private void FixedUpdate()
    {
        //Tell the motor to move using the input values
        motor.ProcessMove(playerActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(playerActions.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        playerActions.Enable();
    }
    private void OnDisable()
    {
        playerActions.Disable();
    }

}
