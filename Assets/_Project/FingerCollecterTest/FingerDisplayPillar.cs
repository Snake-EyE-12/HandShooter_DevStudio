using System;
using UnityEngine;

public class FingerDisplayPillar : MonoBehaviour, Interactable
{
    [SerializeField] private FingerDefinition fingerDefinition;

    public bool IsInteractable => true;
    public void OnEnterInteractable()
    {
        
    }

    public void OnInteract(Interaction interaction)
    {
        interaction.GetHand().AddFinger(new Finger(fingerDefinition));
    }

    public void OnExitInteractable()
    {
        
    }
}