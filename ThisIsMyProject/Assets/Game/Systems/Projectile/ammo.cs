using UnityEngine;

public class ammo : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Move only on Z axis
        rb.linearVelocity = new Vector3(0f, 0f, speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EndWall"))
        {
            Destroy(gameObject);
        }
    }

    public void OnMultiplierHit()
    {
        Destroy(gameObject);
    }
}