using UnityEngine;
using System.Collections.Generic;

public class TrackGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject tilePrefab;
    public GameObject[] obstaclePrefabs;

    [Header("Settings")]
    public int tilesOnScreen = 8;
    public float tileLength = 30f;
    public float obstacleSpawnChance = 0.4f;

    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnZ = 0f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < tilesOnScreen; i++)
            SpawnTile(i == 0);
    }

    void Update()
    {
        if (!GameManager.Instance.isPlaying) return;

        if (playerTransform.position.z > spawnZ - (tilesOnScreen * tileLength * 0.5f))
            SpawnTile(false);

        if (activeTiles.Count > tilesOnScreen + 2)
        {
            GameObject old = activeTiles[0];
            activeTiles.RemoveAt(0);
            Destroy(old);
        }
    }

    void SpawnTile(bool safeZone)
    {
        GameObject tile = Instantiate(tilePrefab, new Vector3(0, -0.5f, spawnZ), Quaternion.identity);
        activeTiles.Add(tile);

        if (!safeZone && obstaclePrefabs.Length > 0 && Random.value < obstacleSpawnChance)
            SpawnObstaclesOnTile(spawnZ);

        spawnZ += tileLength;
    }

    void SpawnObstaclesOnTile(float tileZ)
    {
        int safeIndex = Random.Range(0, 3);
        float[] lanePositions = { -3f, 0f, 3f };

        for (int i = 0; i < 3; i++)
        {
            if (i == safeIndex) continue;
            float x = lanePositions[i];
            float z = tileZ + Random.Range(5f, 25f);
            int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[prefabIndex], new Vector3(x, 1f, z), Quaternion.identity);
        }
    }
}