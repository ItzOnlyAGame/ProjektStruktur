using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float minSpawnInterval = 2.5f;
    public float maxSpawnInterval = 6f;
    public int maxEnemies = 9;

    private float timer;
    private float nextSpawnTime;
    private int currentEnemies;

    void Start()
    {
        // Set the first random spawn time
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime && currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Assign player reference to the spawned enemy
        EnemyMove enemyScript = enemy.GetComponent<EnemyMove>();
        if (enemyScript != null)
        {
            enemyScript.player = player;
        }

        currentEnemies++;
    }

    // Optional: reduce count when enemy dies
    public void EnemyDied()
    {
        currentEnemies--;
    }
}