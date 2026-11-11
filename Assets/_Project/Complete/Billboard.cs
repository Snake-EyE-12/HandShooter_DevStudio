using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform mainCameraTransform;

    void Start()
    {
        // Cache the camera transform for performance
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        if (mainCameraTransform == null) return;

        // Choice A: Match the camera's exact rotation (Smooth & accurate for moving cameras)
        transform.rotation = mainCameraTransform.rotation;

        // Choice B: Use LookAt if you prefer a strict "look directly at the camera position"
        // transform.LookAt(mainCameraTransform.position);
    }
}