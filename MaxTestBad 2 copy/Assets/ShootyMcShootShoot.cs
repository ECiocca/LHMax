using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyMcShootShoot : MonoBehaviour {
    public float speed = 5;
    Vector3 Direction;

    // Use this for initialization
    void Start () {
        Direction = Camera.main.transform.forward;
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.localPosition += Direction * speed;
    }
}
