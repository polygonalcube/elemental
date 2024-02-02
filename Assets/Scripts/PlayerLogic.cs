using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public MoveComponent mover;
    public ShootingComponent earther;
    public ShootingComponent burner;
    public ShootingComponent winder;

    CharacterController charCon;
    public GameObject shotOrigin;

    //movement
    public InputAction movement;
    public Vector3 movValue = Vector3.zero;

    //element toggle
    public InputAction elementSwitcher;
    public float elemVal;
    public enum Elements
    {
        EARTH,
        FIRE,
        AIR
    }
    public Elements element = Elements.EARTH;

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
        elementSwitcher.Enable();
        shooting.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        elementSwitcher.Disable();
        shooting.Disable();
    }

    void Start()
    {
        mover = GetComponent<MoveComponent>();
        charCon = GetComponent<CharacterController>();
        StartCoroutine(Switch());
    }

    void Update()
    {
        switch(state)
        {
            case States.IDLE:
                ReceiveInput();
                Movement();
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

        elemVal = elementSwitcher.ReadValue<float>();
        shotVal = shooting.ReadValue<float>();
    }

    void Movement()
    {
        mover.Move(movValue);
    }

    void Shooting()
    {
        switch (element)
        {
            case Elements.EARTH:
                if (shotVal > 0f)
                {
                    LayerMask ignoreLayer = LayerMask.NameToLayer("Player");
                    RaycastHit hit;
                    if (Physics.Raycast(shotOrigin.transform.position + (shotOrigin.transform.up * .8f), shotOrigin.transform.forward, out hit, 5f, ignoreLayer))
                    {
                        GameObject pillar = earther.Shoot(transform.position + (transform.forward * 3f) + (Vector3.down * 5f), new Vector3(0f, 1f, 0f), destroyTimer: 7f);
                    }
                }
                break;
            case Elements.FIRE:
                if (shotVal > 0f)
                {
                    burner.Shoot(shotOrigin.transform.position, shotOrigin.transform.forward, destroyTimer: 3f);
                }
                break;
            case Elements.AIR:
                if (shotVal > 0f)
                {
                    winder.Shoot(shotOrigin.transform.position, shotOrigin.transform.forward, destroyTimer: 5f);
                }
                break;
        }
    }
    
    IEnumerator Switch()
    {
        while (true)
        {
            element = Elements.EARTH;
            yield return new WaitUntil(() => elemVal == 0f);
            yield return new WaitUntil(() => elemVal > 0f);
            element = Elements.FIRE;
            yield return new WaitUntil(() => elemVal == 0f);
            yield return new WaitUntil(() => elemVal > 0f);
            element = Elements.AIR;
            yield return new WaitUntil(() => elemVal == 0f);
            yield return new WaitUntil(() => elemVal > 0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        LayerMask stoneLayer = LayerMask.NameToLayer("Stone");
        if (col.gameObject.layer == stoneLayer)
        {
            //transform.position += col.gameObject.GetComponent<PillarLogic>().movRef;
            Debug.Log("pillar");
        }
    }
}
