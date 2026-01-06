using UnityEngine;

public class CoolDudes : MonoBehaviour
{
    [Header("Ring Settings")]
    public GameObject[] rings;      // Isi di Inspector: ring pertama, tengah, dan terakhir
    public int noOfRings = 10;
    public float ringDistance = 5f;

    private float yPos = 0f;

    private void Start()
    {
        // Ring pertama
        SpawnRing(0);

        // Ring tengah
        for (int i = 1; i < noOfRings - 1; i++)
        {
            int middleIndex = Random.Range(1, rings.Length - 1);
            SpawnRing(middleIndex);
        }

        // Ring terakhir
        SpawnRing(rings.Length - 1);
    }

    void SpawnRing(int index)
    {
        if (index < 0 || index >= rings.Length) return;

        GameObject newRing = Instantiate(rings[index], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity);
        newRing.transform.parent = transform;
        yPos -= ringDistance;
    }
}
