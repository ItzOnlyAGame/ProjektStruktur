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
        if (other.gameObject.CompareTag("Ammo"))
        {
            addAmount = addAmount + 1;
            Debug.Log(addAmount);
            other.gameObject.GetComponent<ammo>().OnMultiplierHit();
            if (addAmount <= 5){
                addAmount == 5;
            }
        }
    }

void MultiplyPlayers(Vector3 centerPosition)
    {
        Debug.Log(addAmount);

        int columns = Mathf.CeilToInt(Mathf.Sqrt(addAmount));

        for (int i = 0; i < addAmount; i++)
        {
            // Grid/blob positioning
            int row = i / columns;
            int column = i % columns;

            float offsetX = (column - columns / 2f) * spacing;
            float offsetZ = row * spacing;

            Vector3 spawnPos = centerPosition + new Vector3(Random.Range(-0.15f, 0.15f), 0f, 0f);

            GameObject newPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity);

            // Ignore collisions with all other players
            Collider newCollider = newPlayer.GetComponent<Collider>();

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            }
        }
    }
