using UnityEngine;

public class PrefabRespawner : MonoBehaviour
{
    public GameObject prefabToRespawn;
    public float respawnTime = 5f;

    private void Start()
    {
        // Start the respawn process
        StartRespawnTimer();
    }

    private void StartRespawnTimer()
    {
        // Start respawn timer
        InvokeRepeating("RespawnPrefab", 0f, respawnTime);
    }

    private void RespawnPrefab()
    {
        // Check if there's already an instance of the prefab
        GameObject existingPrefab = GameObject.Find(prefabToRespawn.name + "(Clone)");

        if (existingPrefab == null)
        {
            // Respawn the prefab at the specified position
            Instantiate(prefabToRespawn, transform.position, Quaternion.identity);
        }
    }
}
