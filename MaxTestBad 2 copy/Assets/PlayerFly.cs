using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour {
    public float speed = 1;
    public float impulse = 0;
    // Use this for initialization
    void Start () {

        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q)){
            impulse = 1;
        }
        else{
            impulse = 0;
        };
        this.transform.localPosition += Camera.main.transform.forward*impulse*speed;

        if (Input.GetKey(KeyCode.Escape)) ;{
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
