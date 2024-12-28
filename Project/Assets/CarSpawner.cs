using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // Drag your car prefab into this field in the Inspector
    public Transform spawnPoint; // Define the spawn point (or leave it empty for random spawn)
    public KeyCode spawnKey = KeyCode.C; // Change this to your preferred key

    public float spawnRadius = 5f; // Radius for random spawn position around the spawn point

    void Update()
    {
        // Check if the spawn key is pressed
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        Vector3 spawnPosition;

        // If a spawn point is defined, use it; otherwise, spawn randomly around the center
        if (spawnPoint != null)
        {
            spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = spawnPoint.position.y; // Keep the cars on the ground level
        }
        else
        {
            spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = transform.position.y; // Adjust height for ground level
        }

        // Instantiate the car at the spawn position
        Instantiate(carPrefab, spawnPosition, Quaternion.identity);
    }
}

