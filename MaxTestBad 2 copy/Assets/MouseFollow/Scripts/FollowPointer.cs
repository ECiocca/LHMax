using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour {


    public MouseFollow pointer;

    public float fForce = 5.0F;
    public float fImpulseForce = 1.0F;
  
    bool bMouseDown = false;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //always be LOOKING at the pointer
        //calculate the vector from the pointer to me
        Vector3 v3Look = pointer.transform.position;
        //we don't care about the y difference
        v3Look.y = this.transform.position.y;

        //if the pointer is a little distance from self
        if (v3Look.magnitude > 0.01F)
        {
            //look at the pointer
            transform.LookAt(v3Look);

            //only follow the pointer if we are on the floor
            if (pointer.IsOnFloor)
            {
                //give a nudge toward the pointer
                Vector3 v3Delta = pointer.transform.position - this.transform.position;
                v3Delta.y = 0;

                GetComponent<Rigidbody>().AddForce(v3Delta * (fForce));

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Rigidbody>().AddForce(v3Delta.normalized * (fImpulseForce), ForceMode.Impulse);
                }
            }

        }


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");
            bMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Up");
            bMouseDown = false;
        }

    }
}
