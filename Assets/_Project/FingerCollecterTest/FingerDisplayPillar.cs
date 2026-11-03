using System;
using UnityEngine;

public class FingerDisplayPillar : MonoBehaviour, Interactable
{
    [SerializeField] private FingerDefinition fingerDefinition;
    [SerializeField] private GameObject fingerDisplay;
    private void Start()
    {
        DisplayFinger();
    }

    public void DisplayFinger()
    {
        fingerDisplay.SetActive(true);
    }

    public void HideFinger()
    {
        fingerDisplay.SetActive(false);
    }

    public InteractionResult Interact(InteractionData interactionData)
    {
        if (fingerDisplay.activeSelf)
        {
            HideFinger();
            interactionData.Hand.AddFinger(new Finger(fingerDefinition));
        }

        return null;
    }
}