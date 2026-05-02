using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float spawnInterval = 3f;
    public int maxEnemies = 5;

    private float timer;
    private int currentEnemies;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentEnemies < maxEnemies)
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