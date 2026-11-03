using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float range = 20f;
    [SerializeField] private Camera cam;
    

    public void Interact(InteractionData interaction)
    {
        TryInteract(interaction);
    }

    private void TryInteract(InteractionData interaction)
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!Physics.Raycast(ray, out RaycastHit hit, range))
            return;

        Interactable interactable = hit.collider.GetComponentInParent<Interactable>();
        if (interactable == null)
            interactable = hit.collider.GetComponentInChildren<Interactable>();

        if (interactable == null)
            return;

        interactable.Interact(interaction);
    }
}