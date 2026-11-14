using UnityEngine;
using UnityEngine.UI;

public class SlotDisplay : MonoBehaviour
{
    [SerializeField] private Image iconRenderer;
    public void SetIcon(Sprite sprite)
    {
        iconRenderer.sprite = sprite;
    }
}