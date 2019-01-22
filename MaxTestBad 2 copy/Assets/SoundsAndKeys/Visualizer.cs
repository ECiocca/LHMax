using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour {

    public GameObject visObject;

    public Color[] colors;

    //the last time any key was pressed
    float fLastKeypress = 0.0F;

    //the last time a particular key was pressed
    float[] fLastTimeStruck = new float[]
    {
        float.NaN,
        float.NaN,
        float.NaN,
        float.NaN,
        float.NaN,
        float.NaN,
        float.NaN,
        float.NaN,
        float.NaN
    };

    //how long does a color flash last?
    const float kfDuration = 0.75F;

	// Use this for initialization
	void Start () {
		
	}
	

    void _TestKey(KeyCode key, int idx)
    {
        if (Input.GetKeyDown(key))
        {
            fLastTimeStruck[idx] = Time.realtimeSinceStartup;
            fLastKeypress = Time.realtimeSinceStartup;
        }
        if (Input.GetKeyUp(key))
        {
            fLastTimeStruck[idx] = float.NaN;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _TestKey(KeyCode.Alpha1, 0);
        _TestKey(KeyCode.Alpha2, 1);
        _TestKey(KeyCode.Alpha3, 2);
        _TestKey(KeyCode.Alpha4, 3);
        _TestKey(KeyCode.Alpha5, 4);
        _TestKey(KeyCode.Alpha6, 5);
        _TestKey(KeyCode.Alpha7, 6);
        _TestKey(KeyCode.Alpha8, 7);
        _TestKey(KeyCode.Alpha9, 8);

        float r = 0.0F;
        float g = 0.0F;
        float b = 0.0F;

        for (int i = 0; i < 9; ++i)
        {
            //skip if it's not pressed
            if (float.IsNaN(fLastTimeStruck[i])) continue;

            //add in a color which dims over time
            float fPerc = 1.0F - Mathf.Clamp01((Time.realtimeSinceStartup - fLastTimeStruck[i]) / kfDuration);
            r = Mathf.Clamp01(r+(colors[i].r * fPerc));
            g = Mathf.Clamp01(g +(colors[i].g * fPerc));
            b = Mathf.Clamp01(b +(colors[i].b * fPerc));
        }

        visObject.GetComponent<Renderer>().material.color = new Color(r, g, b);

        //also pop the object
        float fAnykeyPerc = Mathf.Clamp01(1.0F - Mathf.Clamp01((Time.realtimeSinceStartup - fLastKeypress) / kfDuration));

        float fScale = fAnykeyPerc + 5.0F;
        visObject.transform.localScale = new Vector3(fScale, fScale, fScale);



    }
}
