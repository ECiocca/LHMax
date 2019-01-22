using UnityEngine;
using System.Collections;

public class MouseCollider : MonoBehaviour
{

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Cheese")
        {
            //remove the cheese, play a squeak
            GameObject.Destroy(collision.collider.gameObject);

            AudioSource aSource = GetComponent<AudioSource>();
            if (aSource != null)
            {
                aSource.Play();
            }
        }

    }
}