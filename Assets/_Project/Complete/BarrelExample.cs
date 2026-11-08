using UnityEngine;

public class BarrelExample : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private float smallForce = 2f;
    [SerializeField] private float mediumForce = 6f;
    [SerializeField] private float upwardForce = 1f;

    public void TakeDamage(int amount)
    {
        if (amount < 1.5f) Small();
        else if (amount < 8) Medium();
        else Large();
    }

    private void Small()
    {
        ApplyForce(smallForce);
    }

    private void Medium()
    {
        ApplyForce(mediumForce);
    }

    private void ApplyForce(float force)
    {
        rb.AddForce(cam.transform.forward * force, ForceMode.Impulse);
        rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
    }

    private void Large()
    {
        Destroy(gameObject);
    }
}