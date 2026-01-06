using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;  // Prefab platform
    public Transform player;           // Player
    public float spawnDistance = 5f;   // Jarak antar platform

    private float nextSpawnY;          // Titik Y untuk spawn berikutnya

    private void Start()
    {
        // Set posisi awal spawn sama dengan posisi spawner
        nextSpawnY = transform.position.y;

        // Spawn beberapa platform awal (opsional)
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        // Jika player mendekati platform paling atas, spawn platform baru
        if (player.position.y + 10f > nextSpawnY)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        Vector3 spawnPos = new Vector3(0, nextSpawnY, 0);
        Instantiate(platformPrefab, spawnPos, Quaternion.identity);

        nextSpawnY += spawnDistance; // Geser ke atas
    }
}
