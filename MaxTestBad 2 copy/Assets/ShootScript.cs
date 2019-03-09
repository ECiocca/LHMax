using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject go = Instantiate(bullet);
            go.transform.position = bulletSpawn.transform.position;
            go.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
