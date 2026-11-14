using UnityEngine;
using System.Linq;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private Interactor interactor;

    private Interactable[] currentInteractables = System.Array.Empty<Interactable>();

    private void Update()
    {
        Interactable[] found = interactor.FindInteractables();

        foreach (Interactable interactable in currentInteractables.Except(found))
            interactable.OnExitInteractable();

        foreach (Interactable interactable in found.Except(currentInteractables))
            interactable.OnEnterInteractable();

        currentInteractables = found;
    }

    public void Interact(Interaction interaction)
    {
        foreach (Interactable interactable in currentInteractables)
            interactable.OnInteract(interaction);
    }

    private void OnDisable()
    {
        foreach (Interactable interactable in currentInteractables)
            interactable.OnExitInteractable();

        currentInteractables = System.Array.Empty<Interactable>();
    }
}