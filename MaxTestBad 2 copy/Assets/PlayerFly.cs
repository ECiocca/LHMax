using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour {
    public float speed = 1;
    public float impulse = 0;
    public float impulseTimer = 0;
    public bool superFast = false;

    public float superFastTimer;
    public bool superFastTimerStart;
    public float centerImpulse = 1;
    public GameObject Camera;
    bool hasCameraChild;
    // Use this for initialization
    void Start () {

        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {
        hasCameraChild = Camera.GetComponent<CameraScrpit2>().isAirplaneChild;

        if (hasCameraChild == true)
        {
            //superspeed
            if (Input.GetKey(KeyCode.Space) && superFastTimerStart == false)
            {
                superFast = true;
                superFastTimerStart = true;

            }

            if (superFastTimerStart == true)
            {
                superFastTimer += Time.deltaTime;
            }

            if (superFastTimer >= 2)
            {
                superFast = false;
            }

            if (superFastTimer >= 6)
            {
                superFastTimer = 0;
                superFastTimerStart = false;
            }

            //centerImpulse
            if (Input.GetKey(KeyCode.LeftShift))
            {
                centerImpulse = 0;
            }

            if (!Input.GetKey(KeyCode.LeftShift))
            {
                centerImpulse = 1;
            }

            if (impulse > centerImpulse)
            {
                impulse -= .1f * Time.deltaTime;
            }

            if (impulse < centerImpulse)
            {
                impulse += .1f * Time.deltaTime;
            }

            //changes gravity
            if (impulse > .5)
            {
                GetComponent<Rigidbody>().useGravity = false;
            }

            if (impulse < .5)
            {
                GetComponent<Rigidbody>().useGravity = true;
            }


            //moves plane
            if (superFast == true)
            {
                impulse += 1;
            }

            //transform.forward to move forward
            this.transform.localPosition += this.transform.forward * impulse * speed;

            if (superFast == true)
            {
                impulse -= 1;
            }

            //transform.up to allow you to look down and move up
            this.transform.localPosition += this.transform.up * impulse * speed;

            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}