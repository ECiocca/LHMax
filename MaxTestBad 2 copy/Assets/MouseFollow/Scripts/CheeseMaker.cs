using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseMaker : MonoBehaviour {

    public GameObject prefabCheese;

    float fLastCheese = float.MinValue;

    public float fCheeseDuration = 5.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//every 5 seconds, make a cheese
        
        if (Time.realtimeSinceStartup - fLastCheese >= fCheeseDuration)
        {
            fLastCheese = Time.realtimeSinceStartup;
            //make a cheese
            GameObject newCheese = GameObject.Instantiate(prefabCheese);

            //randomly rotate
            newCheese.transform.RotateAround(new Vector3(0, 1, 0), Random.Range(-180, 180));

            //move it someplace random

            float fScaleX = (transform.localScale.x/2)-0.5F;
            float fScaleZ = (transform.localScale.z/2)-0.5F;

            Vector3 v3NewPos = this.transform.position + new Vector3(
                Random.Range(-fScaleX, fScaleX),
                0.1F,
                Random.Range(-fScaleZ, fScaleZ)
            );

            newCheese.transform.position = v3NewPos;

        }

    }
}
