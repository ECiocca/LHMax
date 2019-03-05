using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrpit2 : MonoBehaviour
{
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = -Input.GetAxis("Mouse Y");
    public float mouseSensitivity = 100.0f;
    public float rotY;
    public float rotX;
    public float rotZ;
    public GameObject airplane;
    // Start is called before the first frame update
    void Start()
    {
        rotY = this.gameObject.transform.localRotation.y;
        rotX = this.gameObject.transform.localRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
        rotZ = 0.00f;

        rotY = Mathf.Clamp(rotY, -30, 30);
        rotX = Mathf.Clamp(rotX, -30, 30);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.localRotation = localRotation;

        airplane.transform.localRotation *= Quaternion.Euler(rotX*Time.deltaTime, rotY*Time.deltaTime, rotZ*Time.deltaTime);
    }
}
