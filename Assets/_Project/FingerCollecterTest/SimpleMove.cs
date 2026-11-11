using UnityEngine;
using UnityEngine.InputSystem; // 1. Add the New Input System namespace

public class SimpleMove : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5.0f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 2. Read input from the Keyboard directly
        Vector2 inputMove = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) inputMove.y = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) inputMove.y = -1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) inputMove.x = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) inputMove.x = 1f;
        }

        // Normalize to prevent diagonal speeding
        if (inputMove.magnitude > 1) inputMove.Normalize();

        // 3. Calculate movement direction relative to the player
        Vector3 move = transform.right * inputMove.x + transform.forward * inputMove.y;
        controller.Move(move * (speed * Time.deltaTime));

        // Apply basic gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}