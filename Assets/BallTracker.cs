using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public Dictionary<string, Vector3> coords = new Dictionary<string, Vector3>
    {
        {"backboard", new Vector3()},
        {"floor", new Vector3()},
    };

    public GameObject Sphere;
    

    public bool thrown = false;
    public bool hitRim = false;
    public bool hitBackboard = false;


    public AudioSource BounceSound;
    public AudioSource RimSound;

    public string objectTag = "Ball";
    public void DeleteObjectsWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objectTag);
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

    public GameObject[] GetObjects() {
        return GameObject.FindGameObjectsWithTag(objectTag);
    }

    void Update()
    {
        Debug.Log(Sphere.transform.position);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        BounceSound.Stop();
        BounceSound.Play();

        if (collision.gameObject.CompareTag("Backboard"))
        {
            hitBackboard = true;
            GameObject[] obj = GetObjects();
            coords["backboard"] = obj[0].transform.position;
        }
        if (collision.gameObject.CompareTag("Rim"))
        {
            RimSound.Stop();
            RimSound.Play();
            hitRim = true;
        }
    }

    void OnTriggerEnter(Collider collision) {

        if (collision.gameObject.CompareTag("ThrowTracker"))
        {
            if (!thrown) {
                thrown = true;
            }
            
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            if (thrown) {
                thrown = false;
                GameObject[] obj = GetObjects();
                coords["floor"] = obj[0].transform.position;
                // Here is where the instance ends and we will compute feedback
                // ====================

                // TODO

                // ====================
                // Delete everything and start over
                hitBackboard = false;
                hitRim = false;
                DeleteObjectsWithTag();
            }
            
        }
    }
}
