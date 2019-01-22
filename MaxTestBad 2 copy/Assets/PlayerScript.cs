using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1.0F;

    public Transform forwardThing;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;

        float impulse = (Input.GetKey(KeyCode.Q) ? 1.0F : 0.0F);
        float blast = impulse * speed * Time.deltaTime;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        transform.Translate(strafe, 0, translation);
        //transform.Translate(0,0,translation * blast);
        transform.Translate(0, 0, blast);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
//Camera.Main.Vector.Forward
