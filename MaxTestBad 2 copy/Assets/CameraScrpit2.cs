using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrpit2 : MonoBehaviour
{
    float mouseX;
    float mouseY;
    public float mouseSensitivity = 100.0f;
    public float rotY;
    public float rotX;
    public float rotZ = 0;
    float currentX;
    float currentY;
    float currentZ;
    public float speed = .5f;
    public bool isAirplaneChild;
    public GameObject airplane;
    // Start is called before the first frame update
    void Start()
    {
        rotY = this.gameObject.transform.localRotation.y;
        rotX = this.gameObject.transform.localRotation.x;
        currentX = 0;
        currentY = 0;
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

        if (gameObject.transform.parent == airplane.transform)
        {
            isAirplaneChild = true;
        }

        if(isAirplaneChild == true)
        {
            rotY = Mathf.Clamp(rotY, -30, 30);
            rotX = Mathf.Clamp(rotX, -30, 30);
        }

        if (isAirplaneChild == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.localPosition += this.transform.forward * Time.deltaTime * speed;
            }
        }

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, rotZ);
        transform.localRotation = localRotation;

        currentX += rotX * Time.deltaTime;
        currentY += rotY * Time.deltaTime;
        currentZ = 0;

        if (isAirplaneChild == true)
        {
            airplane.transform.rotation = Quaternion.Euler(currentX, currentY, currentZ);
        }
    }
}
