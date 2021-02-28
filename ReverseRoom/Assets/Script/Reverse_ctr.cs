using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_ctr : MonoBehaviour
{
    Camera cam;
    float frame_rotato;

    bool reverse_check;

    // Start is called before the first frame update
    void Start()
    {
        reverse_check = false;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.orthographicSize == 8.0f)
        {
            reverse_check = true;
        }

        if(reverse_check == true)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                ReverseX();
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ReverseY();
            }
        }
    }

    void ReverseX()
    {
        frame_rotato = Mathf.Clamp(frame_rotato + Time.deltaTime * 200, 0, 180);
        transform.eulerAngles = new Vector3(frame_rotato, 0.0f, 0.0f);
    }

    void ReverseY()
    {
        frame_rotato = Mathf.Clamp(frame_rotato + Time.deltaTime * 200, 0, 180);
        transform.eulerAngles = new Vector3(0.0f, frame_rotato, 0.0f);
    }
}
