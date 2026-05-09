using UnityEngine;

public class MultiplierSpeed : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.linearVelocity;
        
        velocity.x = 0f;
        velocity.z = -speed;

        rb.linearVelocity = velocity;        
    }
}
