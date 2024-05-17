using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject Sphere;

    public string objectTag = "Ball";

    public void SpawnObject()
    {
        // Instantiate the prefab at the position and rotation of the spawner
        GameObject newObject = Instantiate(Sphere, transform.position, transform.rotation);

        // Set the tag of the new object
        newObject.tag = objectTag;
    }

    public void DeleteObjectsWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objectTag);
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

    void Update()
    {
        bool frontTriggerPressed = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if(frontTriggerPressed) {
            DeleteObjectsWithTag();
            SpawnObject();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            DeleteObjectsWithTag();
            SpawnObject();
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            DeleteObjectsWithTag();
        }
    }
    
}
