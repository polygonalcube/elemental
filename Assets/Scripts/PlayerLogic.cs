using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public MoveComponent mover;
    public ShootingComponent shooter;

    CharacterController charCon;
    public GameObject shotOrigin;

    //movement
    public InputAction movement;
    public Vector3 movValue = Vector3.zero;

    //shooting
    public InputAction shooting;
    public float shotVal;

    public enum States
    {
        IDLE,
        MOVE
    }
    public States state = States.IDLE;

    void OnEnable()
    {
        movement.Enable();
        shooting.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        shooting.Disable();
    }

    void Start()
    {
        mover = GetComponent<MoveComponent>();
        shooter = GetComponent<ShootingComponent>();
        charCon = GetComponent<CharacterController>();
    }

    void Update()
    {
        switch(state)
        {
            case States.IDLE:
                ReceiveInput();
                //Movement();
                Shooting();
                if (movValue != Vector3.zero)
                {
                    state = States.MOVE;
                }
                break;
            case States.MOVE:
                ReceiveInput();
                Movement();
                Shooting();
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
        movValue = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * movValue;
        
        shotVal = shooting.ReadValue<float>();
    }

    void Movement()
    {
        mover.Move(movValue);
        mover.ResetY();
    }

    void Shooting()
    {
        if (shotVal > 0)
        {
            shooter.Shoot(shotOrigin.transform.position, shotOrigin.transform.forward);
        }
    }
}
