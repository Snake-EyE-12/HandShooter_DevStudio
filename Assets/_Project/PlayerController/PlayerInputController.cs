using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInputReceiver receiver;
    private void Awake()
    {
        receiver = GetComponent<PlayerInputReceiver>();
    }

    public void OnMove(InputValue value)
    {
        receiver.Move(value.Get<Vector2>());
    }

    public void OnAttack(InputValue value)
    {
        receiver.Use();
    }

    public void OnInteract(InputValue value)
    {
        receiver.Interact();
    }

    public void OnLook(InputValue value)
    {
        receiver.Look(value.Get<Vector2>());
    }
    public void OnScrollWheel(InputValue value)
    {
        receiver.Scroll(value.Get<Vector2>().y);
    }
    
}

public interface PlayerInputReceiver
{
    public void Move(Vector2 inputDirection);
    public void Use();
    public void Interact();
    public void Look(Vector2 look);
    public void Scroll(float delta);
}