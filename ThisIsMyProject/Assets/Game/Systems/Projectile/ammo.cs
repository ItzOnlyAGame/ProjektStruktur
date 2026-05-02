using UnityEngine;

public class ammo : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Move only on Z axis (forward)
        rb.linearVelocity = new Vector3(0f, 0f, speed);

        // Destroy after some time (cleanup)
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // kill enemy
            Destroy(gameObject);           // destroy projectile
        }
    }
}