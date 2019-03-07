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
    public float rotZ = 0;
    float currentX;
    float currentY;
    public GameObject airplane;
    // Start is called before the first frame update
    void Start()
    {
        rotY = this.gameObject.transform.localRotation.y;
        rotX = this.gameObject.transform.localRotation.x;
        currentX = ((airplane.transform.rotation.x + rotX * Time.deltaTime) - 0) * (180 - 0) / (1 - 0);
        currentY = ((airplane.transform.rotation.y + rotY * Time.deltaTime) - 0) * (180 - 0) / (1 - 0);
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            rotZ += 1 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotZ -= 1 * Time.deltaTime;
        }


        rotY = Mathf.Clamp(rotY, -30, 30);
        rotX = Mathf.Clamp(rotX, -30, 30);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, rotZ);
        transform.localRotation = localRotation;

        airplane.transform.rotation = Quaternion.Euler(currentX, currentY, 0);

        currentX = ((airplane.transform.rotation.x + rotX * Time.deltaTime) - 0) * (180 - 0) / (1 - 0);
        currentY = ((airplane.transform.rotation.y + rotY * Time.deltaTime) - 0) * (180 - 0) / (1 - 0);
    }
}
