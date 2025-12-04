using UnityEngine;

public class GridBlockGenerator : MonoBehaviour
{
    public Transform player;

    [Header("Prefabs")]
    public GameObject stonePrefab;
    public GameObject[] orePrefabs;   // 0 = copper, 1 = iron, 2 = gold, dll
    public GameObject borderPrefab;   // ⬅ tambahkan ini

    [Header("Grid Settings")]
    public int blocksPerRow = 5;
    public float xMin = -3f;
    public float xMax = 3f;
    public float yStep = 1.5f;
    public int rowsAhead = 8;
    public float xRandomOffset = 0.3f;

    private float nextSpawnY;

    void Start()
    {
        nextSpawnY = player.position.y - yStep;
        SpawnBatch(rowsAhead);
    }

    void Update()
    {
        if (player.position.y - 10f < nextSpawnY)
        {
            SpawnBatch(1);
        }
    }

    void SpawnBatch(int rows)
    {
        float stepX = (xMax - xMin) / (blocksPerRow - 1);

        for (int r = 0; r < rows; r++)
        {
            // Spawn blok per baris
            for (int i = 0; i < blocksPerRow; i++)
            {
                Vector3 spawnPos = new Vector3(
                    xMin + i * stepX + Random.Range(-xRandomOffset, xRandomOffset),
                    nextSpawnY,
                    0
                );

                GameObject blockToSpawn = ChooseBlock(nextSpawnY);
                Instantiate(blockToSpawn, spawnPos, Quaternion.identity);
            }

            // ⭐ Spawn border kiri
            Vector3 leftBorderPos = new Vector3(xMin - 1f, nextSpawnY, 0);
            Instantiate(borderPrefab, leftBorderPos, Quaternion.identity);

            // ⭐ Spawn border kanan
            Vector3 rightBorderPos = new Vector3(xMax + 1f, nextSpawnY, 0);
            Instantiate(borderPrefab, rightBorderPos, Quaternion.identity);

            nextSpawnY -= yStep;
        }
    }



    GameObject ChooseBlock(float y)
    {
        float depth = -y;

        // CHANCE SYSTEM
        float oreChance = GetOreChance(depth);

        if (Random.value < oreChance)
        {
            return GetOreByDepth(depth);
        }

        return stonePrefab;
    }

    float GetOreChance(float depth)
    {
        // semakin dalam → makin besar chance ore
        if (depth < 20) return 0.10f;  // 5%
        if (depth < 50) return 0.11f;  // 10%
        if (depth < 100) return 0.12f; // 15%
        if (depth < 250) return 0.13f; // 20%

        return 0.15f; // max 25%
    }

    GameObject GetOreByDepth(float depth)
    {
        if (depth < 20) return orePrefabs[0];       // Copper
        if (depth < 50) return orePrefabs[1];       // Iron
        if (depth < 100) return orePrefabs[2];      // Silver
        if (depth < 150) return orePrefabs[3];      // Gold
        if (depth < 180) return orePrefabs[4];      // Crystal

        return Random.value < 0.5f ? orePrefabs[4] : orePrefabs[5];
    }
}
