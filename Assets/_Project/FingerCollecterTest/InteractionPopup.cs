using UnityEngine;


public class InteractionPopup : MonoBehaviour
{
    [SerializeField] private GameObject billboard;
    public void Pop()
    {
        billboard?.SetActive(true);
    }

    public void Hide()
    {
        billboard?.SetActive(false);
    }
}
