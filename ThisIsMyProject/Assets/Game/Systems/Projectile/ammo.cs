using UnityEngine;

public class ammo : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Move only on Z axis (forward)
        rb.linearVelocity = new Vector3(0f, 0f, speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // kill enemy
            Destroy(gameObject);           // destroy projectile
        }

        if (collision.gameObject.CompareTag("EndWall"))
        {
            Destroy(gameObject);
        }
    }
}