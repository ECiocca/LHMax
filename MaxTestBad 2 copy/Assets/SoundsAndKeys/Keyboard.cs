using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {

    public AudioSource[] sources;
    bool _bShift = false;

    // Use this for initialization
    void Start () {
		
	}
	
    void _TestKey(KeyCode key, int idx)
    {
        if (Input.GetKeyDown(key))
        {
            sources[idx].Play();
        }
        if (Input.GetKeyUp(key))
        {
            sources[idx].Stop();
        }
    }


    // Update is called once per frame
    void Update () {
        _TestKey(KeyCode.Alpha1, 0);
        _TestKey(KeyCode.Alpha2, 1);
        _TestKey(KeyCode.Alpha3, 2);
        _TestKey(KeyCode.Alpha4, 3);
        _TestKey(KeyCode.Alpha5, 4);
        _TestKey(KeyCode.Alpha6, 5);
        _TestKey(KeyCode.Alpha7, 6);
        _TestKey(KeyCode.Alpha8, 7);
        _TestKey(KeyCode.Alpha9, 8);

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _bShift = !_bShift;

            for (int i = 0; i < 9; ++i)
            {
                sources[i].pitch = (_bShift) ? 2.0F : 1.0F;
            }
        }


    }
}
