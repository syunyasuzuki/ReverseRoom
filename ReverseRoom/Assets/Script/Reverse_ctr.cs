using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_ctr : MonoBehaviour
{
    Camera cam;
    float room_rotato_x;
    float room_rotato_y;
    float room_rotato_Z;
    float rot_Z_max = 90.0f;

    bool reverse_check;
    bool rotX_check;
    bool rotY_check;
    bool rotZ_check;

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

        if (reverse_check == true)
        {
            Reverse();
        }

        transform.eulerAngles = new Vector3(room_rotato_x, room_rotato_y, room_rotato_Z);
    }

    void Reverse()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            reverse_check = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotY_check = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotY_check = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotX_check = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotX_check = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotZ_check = true;
        }

        if(rotY_check == true)
        {
            room_rotato_y = Mathf.Clamp(room_rotato_y + Time.deltaTime * 200, 0, 180);
        }
        if(rotY_check == false)
        {
            room_rotato_y = Mathf.Clamp(room_rotato_y - Time.deltaTime * 200, 0, 180);
        }

        if(rotX_check == true)
        {
            room_rotato_x = Mathf.Clamp(room_rotato_x + Time.deltaTime * 200, 0, 180);
        }
        if(rotX_check == false)
        {
            room_rotato_x = Mathf.Clamp(room_rotato_x - Time.deltaTime * 200, 0, 180);
        }

        if(rotZ_check == true)
        {
            if(room_rotato_Z >= 90.0f)
            {
                rot_Z_max = 180.0f;
            }
            if(room_rotato_Z >= 180.0f)
            {
                rot_Z_max = 270.0f;
            }
            if(room_rotato_Z >= 270.0f)
            {
                rot_Z_max = 360f;
            }
            if(room_rotato_Z >= 360.0f)
            {
                rot_Z_max = 90.0f;
                room_rotato_Z = 0.0f;
            }
            room_rotato_Z += 200.0f * Time.deltaTime;
            if(room_rotato_Z >= rot_Z_max)
            {
                room_rotato_Z = rot_Z_max;
                rotZ_check = false;
            }
        }
    }
}
