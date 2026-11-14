using System;
using UnityEngine;

public class GunAdder : MonoBehaviour, Interactable
{
    private bool done;
    [SerializeField] private WeaponDefinition def;
    public bool IsInteractable => !done;
    public void OnEnterInteractable()
    {
        
    }

    public void OnInteract(Interaction interaction)
    {
        done = true;
        interaction.AddGun(def);
    }

    public void OnExitInteractable()
    {
        
    }
}