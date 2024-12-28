using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public GameObject PointLightPrefab; // Reference to the spotlight prefab
    public BoxCollider RoomBounds;    // Reference to the Box Collider defining room bounds

    void Update()
    {
        // Check if the "+" key is pressed
        if (Input.GetKeyDown(KeyCode.Equals)) // "=" key is "+" when Shift is held
        {
            CreateSpotlight();
            CreateSpotlight();
            CreateSpotlight();
            CreateSpotlight();
            CreateSpotlight();
        }
    }

    void CreateSpotlight()
    {
        if (RoomBounds == null)
        {
            Debug.LogError("RoomBounds is not assigned!");
            return;
        }

        // Get the bounds of the BoxCollider
        Bounds bounds = RoomBounds.bounds;

        // Generate a random position within the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 randomPosition = new Vector3(x, y, z);

        // Instantiate the spotlight at the random position
        GameObject newSpotlight = Instantiate(PointLightPrefab, randomPosition, Quaternion.identity);

        // Adjust spotlight properties (optional)
        Light lightComponent = newSpotlight.GetComponent<Light>();
        if (lightComponent != null)
        {
            lightComponent.type = LightType.Point;
            lightComponent.intensity = 1f; // Example intensity
            lightComponent.range = 10f;   // Example range
        }
    }
}

