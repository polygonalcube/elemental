//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLogic : MonoBehaviour
{
    // The script for the first-person camera.

    [SerializeField] float sensitivity = 3f; // Higher values equate to stronger camera rotations.

    //mouse
    public InputAction cam; // Mouse input.

    public Vector2 movValue = Vector2.zero; // The variable that the result of the mouse input will be passed to.
    float xRot = 0f; // The vertical rotation of the camera. Used to make sure players can't look past the top & bottom.
    Transform player; // A reference to the player transform.

    // Required for the input system to function.
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
        Cursor.lockState = CursorLockMode.Locked; // When you click on the game screen, the game will capture your mouse to allow for infinite panning.
        player = GameManager.gm.FindPlayer().transform; // Sets the player variable to the player transform.
    }

    void Update()
    {
        movValue = cam.ReadValue<Vector2>(); // The results of the frame's input gets passed to a variable.
        xRot -= movValue.y * sensitivity * Time.deltaTime; // xRot gets decremented (dec because of Unity rotations) by the y component of input * sensitivity.
        xRot = Mathf.Clamp(xRot, -90f, 90f); // Clamps the xRot variable. This prevents players from looking too far up or down.
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f); // Rotates the camera vertically.
        if (player == null) // If the player variable is null...
        {
            player = GameManager.gm.FindPlayer().transform; // search for the player transform again. This will run each frame until the player is found.
        }
        else // If not null...
        {
            player.Rotate(Vector3.up, movValue.x * sensitivity * Time.deltaTime); // rotate the player horizontally.
        }
    }
}
