using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface Interactable
{
    public bool IsInteractable { get; }
    public void OnEnterInteractable();
    public void OnInteract(Interaction interaction);
    public void OnExitInteractable();
}

public interface Interaction
{
    public Hand GetHand();
    public void AddGun(WeaponDefinition definition);
}