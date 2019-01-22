using System;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Airplane;

    private float AirplaneY = 0;
    private float AirplaneX = 0;
    
    public float speedH = 2f;
    public float speedV = 2f;
    public float LookAmount = 60f;
    
    private float LookMaxY;
    private float LookMinY;
    private float LookMaxX;
    private float LookMinX;

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
        AirplaneY = Input.GetAxis("Airplane Y");
        AirplaneX = Input.GetAxis("Airplane X");
        LookMaxY = Input.GetAxis("Airplane Y") + LookAmount;
        LookMinY = Input.GetAxis("Airplane Y") - LookAmount;
        LookMaxX = Input.GetAxis("Airplane X") + LookAmount;
        LookMinX = Input.GetAxis("Airplane X") - LookAmount;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        if (LookMaxY > 359 && mouseY < 60)
        {
            LookMaxY -= 360;
        }

        if (LookMinY < 0 && mouseY > 60)
        {
            LookMinY += 360;
        }


        if (LookMaxX > 359 && mouseX < 60)
        {
            LookMaxX -= 360;
        }

        if (LookMinX < 0 && mouseX > 60)
        {
            LookMinX += 360;
        }

        //locks carera rotaion
        if (mouseY > LookMaxY)
        {
            mouseY = LookMaxY;
        }

        if (mouseY < LookMinY)
        {
            mouseY = -LookMinY;
        }

        if (mouseX > LookMaxX)
        {
            mouseX = LookMaxX;
        }

        if (mouseX < LookMinX)
        {
            mouseX = -LookMinX;
        }

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        //applies changes

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
   