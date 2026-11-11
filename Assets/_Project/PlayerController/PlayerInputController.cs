
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInputReceiver receiver;

    private void Awake()
    {
        receiver = GetComponent<PlayerInputReceiver>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        receiver.Move(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed) receiver.Use();
        if (context.canceled) receiver.StopUse();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed) receiver.Interact();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        receiver.Look(context.ReadValue<Vector2>());
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        receiver.Scroll(context.ReadValue<Vector2>().y);
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed) receiver.UseAlternate();
    }

    public void OnNumberSelect1(InputAction.CallbackContext context) 
    {
        if (context.performed) receiver.SelectSlot(0);
    }

    public void OnNumberSelect2(InputAction.CallbackContext context) 
    {
        if (context.performed) receiver.SelectSlot(1);
    }

    public void OnNumberSelect3(InputAction.CallbackContext context) 
    {
        if (context.performed) receiver.SelectSlot(2);
    }

    public void OnNumberSelect4(InputAction.CallbackContext context) 
    {
        if (context.performed) receiver.SelectSlot(3);
    }

    public void OnNumberSelect5(InputAction.CallbackContext context) 
    {
        if (context.performed) receiver.SelectSlot(4);
    }

    public void OnNumberSelect6(InputAction.CallbackContext context) 
    {
        if (context.performed) receiver.SelectSlot(5);
    }
}

public interface PlayerInputReceiver
{
    public void Move(Vector2 inputDirection);
    public void Use();
    public void StopUse();
    public void Interact();
    public void Look(Vector2 look);
    public void Scroll(float delta);
    public void UseAlternate();
    public void SelectSlot(int slot);
}
