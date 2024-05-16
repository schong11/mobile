using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBasket : MonoBehaviour
{
    public AudioSource BasketMade;

    // Method to play the sound
    public GameObject Sphere;
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Sphere");
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            // Instantiate(Sphere,transform.position,Quaternion.identity);
            BasketMade.Stop();
            BasketMade.Play();
        }
    }
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "Sphere");
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            // Instantiate(Sphere,transform.position,Quaternion.identity);
            BasketMade.Stop();
            BasketMade.Play();
        }
    }
}
