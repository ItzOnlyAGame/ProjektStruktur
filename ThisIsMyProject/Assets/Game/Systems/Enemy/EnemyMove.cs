using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 4f;
    public float triggerDistance = 5f;
    public Transform player;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance)
        {
            // FULL chase (X and Z)
            Vector3 direction = (player.position - transform.position).normalized;

            velocity.x = direction.x * speed;
            velocity.z = direction.z * speed;
        }
        else
        {
            // Default movement (forward)
            velocity.x = 0f;
            velocity.z = -speed;
        }

        rb.linearVelocity = velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // kill enemy
        }
    }
}