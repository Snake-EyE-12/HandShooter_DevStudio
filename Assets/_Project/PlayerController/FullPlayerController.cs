using System;
using UnityEngine;

public class FullPlayerController : MonoBehaviour, PlayerInputReceiver, Interaction
{
    [SerializeField] private PlayerLocomotionController locomotion;
    [SerializeField] private  PlayerCameraViewController viewer;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private InteractionHandler interactor;
    
    [SerializeField] private Hand myHand;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Move(Vector2 inputDirection)
    {
        locomotion.OnChangeDirection(inputDirection);
    }

    public void Use()
    {
        inventory.Use();
    }

    public void Interact()
    {
        interactor.Interact(this);
    }

    public void Look(Vector2 look)
    {
        viewer.Look(look);
    }

    public void Scroll(float delta)
    {
        inventory.Scroll(delta);
    }

    public Hand GetHand()
    {
        return myHand;
    }

    public void AddGun(WeaponDefinition definition)
    {
        inventory.AddWeapon(definition);
    }
}
