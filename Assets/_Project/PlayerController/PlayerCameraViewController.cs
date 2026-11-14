using UnityEngine;

public class PlayerCameraViewController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float sensitivity = 1f;

    [Header("Pitch")]
    [SerializeField] private float minPitch = -90f;
    [SerializeField] private float maxPitch = 90f;

    [Header("Yaw")]
    [SerializeField] private bool limitYaw;
    [SerializeField] private float minYaw = -90f;
    [SerializeField] private float maxYaw = 90f;

    private float pitch;
    private float yaw;

    private void Awake()
    {
        pitch = _camera.transform.localEulerAngles.x;
        if (pitch > 180f) pitch -= 360f;

        yaw = transform.eulerAngles.y;
        if (yaw > 180f) yaw -= 360f;
    }

    public void Look(Vector2 direction)
    {
        yaw += direction.x * sensitivity;
        pitch -= direction.y * sensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        if (limitYaw) yaw = Mathf.Clamp(yaw, minYaw, maxYaw);

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        _camera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}