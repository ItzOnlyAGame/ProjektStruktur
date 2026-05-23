using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float cooldown = 0.9f;

    private float nextShootTime;

    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + cooldown;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}