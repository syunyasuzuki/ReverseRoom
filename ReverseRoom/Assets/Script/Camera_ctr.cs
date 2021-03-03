using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ctr : MonoBehaviour
{
    Camera cam;

    float normal_size = 5.0f;
    float change_size = 8.0f;

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
        if (Input.GetKeyDown(KeyCode.Z) && cam.orthographicSize <= normal_size)
        {
            size_up = true;
        }
        if (Input.GetKeyDown(KeyCode.X) && cam.orthographicSize >= change_size)
        {
            size_down = true;
        }

        if(size_up == true)
        {
            SizeUp();
        }

        if(size_down == true)
        {
            SizeDown();
        }
    }

    void SizeUp()
    {
        cam.orthographicSize += 5.0f * Time.deltaTime;
        if (cam.orthographicSize >= change_size)
        {
            cam.orthographicSize = change_size;
            size_up = false;
        }
    }

    void SizeDown()
    {
        cam.orthographicSize -= 5.0f * Time.deltaTime;
        if (cam.orthographicSize <= normal_size)
        {
            cam.orthographicSize = normal_size;
            size_down = false;
        }
    }
}
