using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ctr : MonoBehaviour
{
    Camera cam;

    bool size_up;
    bool size_down;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        size_up = false;
        size_down = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && cam.orthographicSize <= 5.0f)
        {
            size_up = true;
        }
        if (Input.GetKeyDown(KeyCode.X) && cam.orthographicSize >= 8.0f)
        {
            size_down = true;
        }

        if(size_up == true)
        {
            cam.orthographicSize += 5.0f * Time.deltaTime;
            if(cam.orthographicSize >= 8.0f)
            {
                size_up = false;
                cam.orthographicSize = 8.0f;
            }
        }

        if(size_down == true)
        {
            cam.orthographicSize -= 5.0f * Time.deltaTime;
            if (cam.orthographicSize <= 5.0f)
            {
                size_down = false;
                cam.orthographicSize = 5.0f;
            }
        }
    }
}
