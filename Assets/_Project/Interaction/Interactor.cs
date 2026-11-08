using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float range = 3f;
    [SerializeField] private Camera cam;

    public Interactable[] FindInteractables()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (!Physics.Raycast(ray, out RaycastHit hit, range))
            return System.Array.Empty<Interactable>();

        Interactable[] parents = hit.collider.GetComponentsInParent<Interactable>();
        Interactable[] children = hit.collider.GetComponentsInChildren<Interactable>();

        return parents.Concat(children)
            .Distinct()
            .Where(x => x.IsInteractable)
            .ToArray();
    }
}