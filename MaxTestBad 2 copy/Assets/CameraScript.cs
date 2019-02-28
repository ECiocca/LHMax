using System;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Airplane;

    public float speedH = 2f;
    public float speedV = 2f;
    public float LookAmount = 60f;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    public float turnSpeed = 0f;
    public float turnTimer = 0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis


    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        //player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
   
        //updates variables
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        //calculate our post-mouse movement 
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        //clamp the rot to a narrow cone

        //clamp the local rotation 
        rotX = Mathf.Clamp(rotX, -30, 30);
        rotY = Mathf.Clamp(rotY, -30, 30);

        const float kRotVal = 0.5F;

        //do a little bit of rotation
        turnTimer += Time.deltaTime;
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)) && turnTimer >= .05)
        {
            turnSpeed += .1f;
            turnTimer = 0;
        }

        if((!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.S)) && turnTimer >= .05)
        {
            turnSpeed = 0;
        }

        turnSpeed = Mathf.Clamp(turnSpeed, 1, 2);

        PlayerFly pf = Airplane.GetComponent<PlayerFly>();
        if (pf != null && pf.impulse >0)
        {
          
            if (rotY > kRotVal)
            {
                //rotY -= kRotVal;
                Airplane.transform.RotateAround(Airplane.transform.up, +kRotVal*(Mathf.PI/180.0F) * turnSpeed * 1000);
            }
            if (rotY < -kRotVal)
            {
                //rotY += kRotVal;
                Airplane.transform.RotateAround(Airplane.transform.up, -kRotVal * (Mathf.PI / 180.0F) * turnSpeed * 1000);
            }


            if (rotX > kRotVal)
            {
                //rotX -= kRotVal;
                Airplane.transform.RotateAround(Airplane.transform.right, +kRotVal * (Mathf.PI / 180.0F) * 1000);
            }
            if (rotX < -kRotVal)
            {
                //rotX += kRotVal;
                Airplane.transform.RotateAround(Airplane.transform.right, -kRotVal * (Mathf.PI / 180.0F) * 1000);
            }

        }

        Vector3 euler = Airplane.transform.localRotation.eulerAngles;
        euler.z = 0;
        //always maintain that the airplane's roll is zero
        Airplane.transform.localRotation = Quaternion.Euler(euler); 

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.localRotation = localRotation;



    }
}
   