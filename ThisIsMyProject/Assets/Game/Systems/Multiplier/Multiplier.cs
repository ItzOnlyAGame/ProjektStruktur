using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public GameObject playerPrefab;

    // How many extra players to add
    public int addAmount = 1;

    // Distance between spawned players
    public float spacing = 1.5f;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        // Prevent multiple activations
        if (activated)
            return;

        // Only activate for player
        if (other.CompareTag("Player"))
        {
            activated = true;

            MultiplyPlayers(other.transform.position);

            // Destroy gate after use
            Destroy(gameObject);
        }
    }

    void MultiplyPlayers(Vector3 centerPosition)
    {
        for (int i = 0; i < addAmount; i++)
        {
            // Spread players left and right
            float offsetX = (i - addAmount / 2f) * spacing;

            Vector3 spawnPos = centerPosition + new Vector3(offsetX, 0f, 0f);

            Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        }
    }
}