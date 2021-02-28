using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_ctr : MonoBehaviour
{

    Rigidbody2D rg2D;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))
        {
            rg2D.velocity = Vector2.zero;
            rg2D.isKinematic = true;
        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.X))
        {
            rg2D.isKinematic = false;
        }
    }
}
