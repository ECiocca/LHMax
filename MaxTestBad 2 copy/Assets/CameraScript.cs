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

        //applies changes

        //clamp the local rotation 
        rotX = Mathf.Clamp(rotX, -30, 30);
        rotY = Mathf.Clamp(rotY, -30, 30);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.localRotation = localRotation;



    }
}
   