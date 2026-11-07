using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    [SerializeField] private List<FingerType> requirements;
    [SerializeField] private GameObject openable;
    public InteractionResult Interact(InteractionData interactionData)
    {
        if (interactionData.Hand.Has(requirements))
        {
            Open();
        }

        return null;
    }

    private void Open()
    {
        openable.SetActive(false);
    }
}
