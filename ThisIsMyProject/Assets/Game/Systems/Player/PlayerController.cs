using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input (-1 for A, +1 for D)
        moveInput = 0f;

        if (Keyboard.current.aKey.isPressed)
            moveInput = -1f;

        if (Keyboard.current.dKey.isPressed)
            moveInput = 1f;
    }

    void FixedUpdate()
    {
        // Apply movement in physics step
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput * speed;
        rb.linearVelocity = velocity;
    }
}