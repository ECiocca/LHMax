using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    GameObject plane;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && plane.transform.position.x - this.transform.position.x <= 4 && plane.transform.position.y - this.transform.position.y <= 4 && plane.transform.position.z - this.transform.position.z <= 4)
        {
            gameObject.transform.parent = plane.gameObject.transform;
        }
    }
}
