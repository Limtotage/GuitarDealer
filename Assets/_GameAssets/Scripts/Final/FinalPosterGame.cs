using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPosterGame : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject posterPrefabs;
    [SerializeField] private GameObject[] bombPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private float spawnInterval = 1f;
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
        bool spawnBomb = Random.value < 0.4f;

        GameObject prefab = spawnBomb
            ? bombPrefab[Random.Range(0, bombPrefab.Length)]
            : posterPrefabs;
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
