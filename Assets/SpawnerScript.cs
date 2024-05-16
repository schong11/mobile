using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject Sphere;

    // Update is called once per frame
    void Update()
    {
        bool frontTriggerPressed = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if(frontTriggerPressed) {
            Instantiate(Sphere,transform.position,Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(Sphere,transform.position,Quaternion.identity);
        }
    }
}
