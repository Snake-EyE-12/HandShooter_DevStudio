using UnityEngine;

public class FullPlayerController : MonoBehaviour, PlayerInputReceiver
{
    [SerializeField] private PlayerLocomotionController locomotion;
    [SerializeField] private  PlayerCameraViewController viewer;
    public void Move(Vector2 inputDirection)
    {
        locomotion.OnChangeDirection(inputDirection);
    }

    public void Use()
    {
        // Inventory
    }

    public void Interact()
    {
        // Interaction Handler
    }

    public void Look(Vector2 look)
    {
        viewer.Look(look);
    }

    public void Scroll(float delta)
    {
        // Inventory
    }
}