using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLocomotionController : MonoBehaviour
{
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float deceleration = 20f;
    [SerializeField] private float maxSpeed = 5f;

    private CharacterController characterController;
    private Vector2 direction;
    private Vector3 velocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnChangeDirection(Vector2 direction)
    {
        this.direction = Vector2.ClampMagnitude(direction, 1f);
    }

    private void Update()
    {
        Vector3 targetVelocity = transform.forward * direction.y + transform.right * direction.x;
        targetVelocity *= maxSpeed;

        float rate = direction.sqrMagnitude > 0 ? acceleration : deceleration;
        velocity = Vector3.MoveTowards(velocity, targetVelocity, rate * Time.deltaTime);

        characterController.Move(velocity * Time.deltaTime);
    }
}