using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controller : MonoBehaviour
{
    public Light[] lights; // Assign your lights in the Inspector (Light1 to Light6)
    public KeyCode[] toggleKeys; // Assign the keys for toggling each light (Alpha1 to Alpha6)

    void Update()
    {
        for (int i = 0; i < lights.Length && i < toggleKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleKeys[i]))
            {
                lights[i].enabled = !lights[i].enabled; // Toggle the light's active state
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) // Example: Space toggles all lights
            {
                foreach (Light light in lights)
                {
                    light.enabled = !light.enabled;
                }
            }
        }
    }
}


