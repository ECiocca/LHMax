using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour {
    public float speed = 1;
    public float impulse = 0;
    public float impulseTimer = 0;
    // Use this for initialization
    void Start () {

        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {

        //MoveForward
        impulseTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.W) && impulseTimer >= .05){
            impulse += .01f;
            impulseTimer = 0f;
        }

        if (Input.GetKey(KeyCode.S) && impulseTimer >= .05 && !Input.GetKey(KeyCode.W))
        {
            impulse -= .01f;
            impulseTimer = 0f;
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && impulseTimer >= .05)
        {
            if(impulse > .5)
            {
                impulse -= .01f;
            }
            if (impulse < .5)
            {
                impulse += .01f;
            }
            impulseTimer = 0;
        }

        impulse = Mathf.Clamp(impulse, -.1f, 1);

        //this.transform.localRotation += 
        this.transform.localPosition += this.transform.forward*impulse*speed;
        this.transform.localPosition += this.transform.up * impulse * speed;

        if (Input.GetKey(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
        }
    }
}