using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] float sensitivity = 3f;

    //mouse
    public InputAction cam;

    public Vector2 movValue = Vector2.zero;
    float xRot = 0f;
    Transform player;

    void OnEnable()
    {
        cam.Enable();
    }

    void OnDisable()
    {
        cam.Disable();
    }

    void Start()
    {
        //you can quit play mode with Ctrl+P
        Cursor.lockState = CursorLockMode.Locked;
        player = GameManager.gm.FindPlayer().transform;
    }

    void Update()
    {
        movValue = cam.ReadValue<Vector2>();
        xRot -= movValue.y * sensitivity * Time.deltaTime;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        if (player == null)
        {
            player = GameManager.gm.FindPlayer().transform;
        }
        else
        {
            player.Rotate(Vector3.up, movValue.x * sensitivity * Time.deltaTime);
        }
    }
}
