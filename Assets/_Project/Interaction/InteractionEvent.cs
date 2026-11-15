using UnityEngine;
using UnityEngine.Events;

public class InteractionEvent : MonoBehaviour, Interactable
{
    [SerializeField] private int usages;
    private int timesUsed;
    [SerializeField] private UnityEvent OnInteractEvent;
    public bool IsInteractable => timesUsed < usages;
    public void OnEnterInteractable()
    {
        
    }

    public void OnInteract(Interaction interaction)
    {
        timesUsed++;
        OnInteractEvent?.Invoke();
    }

    public void OnExitInteractable()
    {
        
    }
}
