using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public Dictionary<string, Vector3> coords = new Dictionary<string, Vector3>
    {
        {"backboard", new Vector3()},
        {"floor", new Vector3()},
        {"rim", new Vector3()},
    };

    public Dictionary<int, Vector3> time_coords = new Dictionary<int, Vector3>{};

    public GameObject Sphere;

    public GameObject basketDetect;

    public string feedback = "";

    public bool thrown = false;
    public bool hitRim = false;
    public bool hitBackboard = false;
    public bool hitBackWall = false;
    public bool madeShot = false;
    public bool height = false;

    public bool left = false;
    public bool right = false;
    public bool morePower = false;

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
        GameObject[] obj = GetObjects();
        if (obj[0].transform.position[1] >= 3 && thrown == true) {
            height = true;
        }
        if (obj[0].transform.position[2] >= -6.18 && thrown == true) {
            morePower = true;
        }
        //GameObject bang = GameObject.Find("Feedback");
        //TextMesh mText = bang.GetComponent<TextMesh>();
        //mText.text = string.Format("{0:N2}", obj[0].transform.position[1]);
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
            GameObject[] obj = GetObjects();
            coords["rim"] = obj[0].transform.position;
            hitRim = true;
        }
        if (collision.gameObject.CompareTag("backWall")) {
            hitBackWall = true;
        }

    }

    void OnTriggerEnter(Collider collision) {

        if (collision.gameObject.CompareTag("ThrowTracker"))
        {
            if (!thrown) {
                thrown = true;
            }
            
        }
        if (collision.gameObject.CompareTag("basketMake")) {
            madeShot = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            if (thrown) {
                thrown = false;
                GameObject[] obj = GetObjects();
                coords["floor"] = obj[0].transform.position;
                // Here is where the instance ends and we will compute feedback
                // ====================
                GameObject bang = GameObject.Find("Feedback");
                TextMesh mText = bang.GetComponent<TextMesh>();

                if (hitRim) {
                    if (coords["rim"][0] > -1.32) {
                        feedback += "Shoot slightly more left";
                    } else {
                        feedback += "Shoot slightly more right";
                    }
                    if (coords["rim"][2] < 5.25) {
                        feedback += " with a tiny bit more power";
                    }
                } else {
                    if (coords["floor"][0] > -1.32) {
                        left = true;
                        if (coords["floor"][0] > -0.7) {
                            feedback += "Shoot far more left";
                        } else {
                            feedback += "Shoot more left";
                        }
                    } else {
                        right = true;
                        if (coords["floor"][0] < -2.3) {
                            feedback += "Shoot far more right";
                        } else {
                            feedback += "Shoot more right";
                        }
                    }

                    if (hitBackWall) {
                        feedback += " with far less power";
                    }
                }
                if (height == false) {
                    feedback = "Release the ball higher";
                    if (morePower == false) {
                        feedback += " and with more power";
                    }
                } else {
                    if (morePower == false) {
                        feedback = "Release the ball lower";
                    }
                }


                if (madeShot) {
                    feedback = "Shot Made!";
                }
                mText.text = feedback;
                

                // ====================
                // Delete everything and start over
                left = false;
                right = false;
                hitBackboard = false;
                hitRim = false;
                hitBackWall = false;
                DeleteObjectsWithTag();
                feedback = "";
                height = false;
                madeShot = false;
                morePower = false;
                time_coords.Clear();

            }
            
        }
    }
}
