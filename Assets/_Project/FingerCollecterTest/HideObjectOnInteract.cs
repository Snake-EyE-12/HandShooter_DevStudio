using UnityEngine;

namespace _Project.FingerCollecterTest
{
    public class HideObjectOnInteract : MonoBehaviour, Interactable
    {
        [SerializeField] private InteractionPopup popup;
        [SerializeField] private GameObject objectToHide;
        private bool done;
        public bool IsInteractable => !done;

        public void OnEnterInteractable()
        {
            popup.Pop();
        }

        public void OnInteract(Interaction interaction)
        {
            done = true;
            objectToHide.SetActive(false);
        }

        public void OnExitInteractable()
        {
            popup.Hide();
        }
    }
}