using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    float depth = 10.0F;

    public Color colorActive;
    public Color colorInactive;

    public Renderer displayMaterial;

   
    public bool IsOnFloor { get; private set; }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
        transform.position = wantedPos;

        //also raycast to see if there are any floors
        Ray r = Camera.main.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, depth));
        RaycastHit hit;
        int mask = 0x01 << 9;  //LayerMask.NameToLayer("Floor");
        IsOnFloor = (Physics.Raycast(r, out hit, Mathf.Infinity, mask));

        if (IsOnFloor)
        {
            displayMaterial.material.SetColor("_TintColor", colorActive);
        }
        else
        {
            displayMaterial.material.SetColor("_TintColor", colorInactive);
        }
    }
}
