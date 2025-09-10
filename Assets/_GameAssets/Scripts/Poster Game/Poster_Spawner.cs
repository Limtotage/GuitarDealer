using System.Collections.Generic;
using UnityEngine;

public class Poster_Spawner : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject[] posterPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private float spawnInterval = 1.5f;
    private List<GameObject> spawnedObjects = new List<GameObject>();


    void Start()
    {

        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnObject));
        foreach (var obj in spawnedObjects)
        {
            if (obj != null)
                Destroy(obj);
        }
    }

    void SpawnObject()
    {
        bool spawnBomb = Random.value < 0.2f;

        GameObject prefab = spawnBomb
            ? bombPrefab
            : posterPrefabs[Random.Range(0, posterPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        float xForce = 0f;
        float yForce = 0f;
        if (spawnPoint.position.x >= 10)
        {
            xForce = Random.Range(-4f, 0);
            yForce = Random.Range(7f, 10f);
        }
        else if (spawnPoint.position.x <= -10)
        {
            xForce = Random.Range(0, 4f);
            yForce = Random.Range(7f, 10f);
        }
        else
        {
            xForce = Random.Range(-2f, 2f);
            yForce = Random.Range(7f, 10f);
        }

        GameObject obj = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        spawnedObjects.Add(obj);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xForce, yForce);
    }
}


