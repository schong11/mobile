using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBasket : MonoBehaviour
{
    //AudioSource audioData;
    void Start()
    {
        //audioData = GetComponent<AudioSource>();
    }

    public GameObject Sphere;
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Sphere");
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Instantiate(Sphere,transform.position,Quaternion.identity);
            //audioData.Play(0);
        }
    }
}
