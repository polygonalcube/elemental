using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public MoveComponent mover;

    public CharacterController charCon;

    //movement
    public InputAction movement;

    public Vector3 movValue = Vector3.zero;

    public enum States
    {
        IDLE,
        MOVE
    }
    public States state = States.IDLE;

    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        switch(state)
        {
            case States.IDLE:
                ReceiveInput();
                //Movement();
                if (movValue != Vector3.zero)
                {
                    state = States.MOVE;
                }
                break;
            case States.MOVE:
                ReceiveInput();
                Movement();
                if (movValue == Vector3.zero)
                {
                    state = States.IDLE;
                }
                break;
        }
    }

    void ReceiveInput()
    {
        movValue = movement.ReadValue<Vector2>();
        movValue = new Vector3(movValue.x, 0f, movValue.y);
    }

    void Movement()
    {
        mover.Move(movValue);
        mover.ResetY();
    }
}
