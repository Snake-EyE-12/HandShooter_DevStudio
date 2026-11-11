using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    [SerializeField] private List<FingerType> requirements;
    [SerializeField] private GameObject openable;


    private void Open()
    {
        Debug.Log("open");
        openable.SetActive(false);
    }

    public bool IsInteractable => true;
    public void OnEnterInteractable()
    {
        
    }

    public void OnInteract(Interaction interaction)
    {
        Debug.Log("Door");
        if (interaction.GetHand().Has(requirements))
        {
            Open();
        }
    }

    public void OnExitInteractable()
    {
        
    }
}
