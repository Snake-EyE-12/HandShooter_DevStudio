using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface Interactable
{
    public InteractionResult Interact(InteractionData interactionData);
}

public class InteractionData
{
    public Hand Hand;

    public InteractionData(Hand hand)
    {
        Hand = hand;
    }
}

public class InteractionResult
{
    
}
