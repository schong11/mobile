using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public GameObject Sphere;  // Reference to the basketball GameObject

    void Update()
    {
        if (Sphere != null)
        {
            Vector3 ballPosition = Sphere.transform.position;  // Get the ball's current position
            Debug.Log("Ball Position: " + ballPosition);     // Log the position to the console
        }
        else
        {
            Debug.LogWarning("Ball GameObject is not assigned.");  // Warn if ball is not assigned
        }
    }
}
