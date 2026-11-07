
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public GameObject playerPrefab;

    public int addAmount = 1;

    public float spacing = 1.5f;

    // Bridge boundaries
    public float bridgeMinX = -0.49f;
    public float bridgeMaxX = 0.55f;

    // Distance from the barriers
    public float edgeMargin = 0.15f;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            MultiplyPlayers(other.transform.position);

            Destroy(gameObject);
        }

        if (other.CompareTag("Ammo"))
        {
            addAmount++;

            // Maximum of 5 additional players
            if (addAmount > 5)
            {
                addAmount = 5;
            }

            Debug.Log(addAmount);

            other.GetComponent<ammo>().OnMultiplierHit();
        }
    }

    void MultiplyPlayers(Vector3 centerPosition)
    {
        Debug.Log(addAmount);

        int columns = Mathf.CeilToInt(Mathf.Sqrt(addAmount));
        int rows = Mathf.CeilToInt((float)addAmount / columns);

        // Calculate usable bridge width
        float minX = bridgeMinX + edgeMargin;
        float maxX = bridgeMaxX - edgeMargin;

        float availableWidth = maxX - minX;

        // Adjust horizontal spacing if necessary
        float spacingX = columns > 1
            ? Mathf.Min(spacing, availableWidth / (columns - 1))
            : 0f;

        // Keep the entire formation inside the bridge
        float groupWidth = (columns - 1) * spacingX;

        float startX = Mathf.Clamp(
            centerPosition.x - groupWidth / 2f,
            minX,
            maxX - groupWidth
        );

        for (int i = 0; i < addAmount; i++)
        {
            int row = i / columns;
            int column = i % columns;

            float offsetX = startX + column * spacingX;

            float offsetZ = (row - (rows - 1) / 2f) * spacing;

            Vector3 spawnPos = new Vector3(
                offsetX + Random.Range(-0.05f, 0.05f),
                centerPosition.y,
                centerPosition.z + offsetZ
            );

            // Spawn player
            GameObject newPlayer = Instantiate(
                playerPrefab,
                spawnPos,
                Quaternion.identity
            );

            // Ignore collisions with other players
            Collider newCollider = newPlayer.GetComponent<Collider>();

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                if (player == newPlayer) continue;

                Collider otherCollider = player.GetComponent<Collider>();

                if (newCollider != null && otherCollider != null)
                {
                    Physics.IgnoreCollision(newCollider, otherCollider);
                }
            }
        }
    }
}
