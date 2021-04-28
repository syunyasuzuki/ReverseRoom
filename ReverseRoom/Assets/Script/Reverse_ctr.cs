using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reverse_ctr : MonoBehaviour
{
    Camera cam;

    AudioSource audio;
    [SerializeField] AudioClip reverse_SE;

    float room_rotato_x;
    float room_rotato_y;
    float room_rotato_Z;
    float rot_Z_max = 90.0f;
    float rot_X_max = 180.0f;
    float rot_Y_max = 180.0f;

    bool reverse_check;
    bool title_reverse_check;
    bool rotX_check;
    bool rotY_check;
    bool rotZ_check;

    public static bool now_rotato;

    public static bool rot_check;

    string now_Scene;

    // Start is called before the first frame update
    void Start()
    {
        now_Scene = SceneManager.GetActiveScene().name;

        reverse_check = false;
        title_reverse_check = false;

        rotX_check = false;
        rotY_check = false;
        rotZ_check = false;

        now_rotato = false;

        rot_check = false;

        cam = Camera.main;

        audio = GetComponent<AudioSource>();
        audio.clip = reverse_SE;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(now_Scene == "TitleScene")
            {
                title_reverse_check = true;
            }
            else
            {
                reverse_check = true;
            }
        }

        if (reverse_check == true)
        {
            Reverse();
        }
        if(title_reverse_check == true)
        {
            Title_Reverse();
        }

        transform.eulerAngles = new Vector3(room_rotato_x, room_rotato_y, room_rotato_Z);
    }

    void Reverse()
    {
        if(now_rotato == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                reverse_check = false;
            }
        }

        if (room_rotato_x >= 90.0f && room_rotato_x <= 95.0f)
        {
            rot_check = true;
        }
        if (room_rotato_y >= 90.0f && room_rotato_y <= 95.0f)
        {
            rot_check = true;
        }
        if (room_rotato_x >= 270.0f && room_rotato_x <= 275.0f)
        {
            rot_check = true;
        }
        if (room_rotato_y >= 270.0f && room_rotato_y <= 275.0f)
        {
            rot_check = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotY_check = true;
            now_rotato = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotY_check = true;
            now_rotato = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotX_check = true;
            now_rotato = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotX_check = true;
            now_rotato = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotZ_check = true;
            now_rotato = true;
        }

        // Y軸回転
        if (rotY_check == true)
        {
            if(room_rotato_y >= 180.0f)
            {
                rot_Y_max = 360.0f;
            }
            if(room_rotato_y >= 360.0f)
            {
                room_rotato_y = 0.0f;
                rot_Y_max = 180.0f;
            }
            room_rotato_y += 300 * Time.deltaTime;
            if(room_rotato_y >= rot_Y_max)
            {
                audio.Play();
                room_rotato_y = rot_Y_max;
                rotY_check = false;
                now_rotato = false;
                rot_check = false;
            }
        }

        // X軸回転
        if (rotX_check == true)
        {
            if (room_rotato_x >= 180.0f)
            {
                rot_X_max = 360.0f;
            }
            if (room_rotato_x >= 360.0f)
            {
                room_rotato_x = 0.0f;
                rot_X_max = 180.0f;
            }
            room_rotato_x += 300 * Time.deltaTime;
            if (room_rotato_x >= rot_X_max)
            {
                audio.Play();
                room_rotato_x = rot_X_max;
                rotX_check = false;
                now_rotato = false;
                rot_check = false;
            }
        }

        // Z軸回転
        if (rotZ_check == true)
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
                audio.Play();
                room_rotato_Z = rot_Z_max;
                rotZ_check = false;
                now_rotato = false;
            }
        }
    }

    void Title_Reverse()
    {
        if (Camera_ctr.size_change == true)
        {
            if (room_rotato_y >= 180.0f)
            {
                rot_Y_max = 360.0f;
            }
            if (room_rotato_y >= 360.0f)
            {
                room_rotato_y = 0.0f;
                rot_Y_max = 180.0f;
            }
            room_rotato_y += 300 * Time.deltaTime;
            if (room_rotato_y >= rot_Y_max)
            {
                audio.Play();
                room_rotato_y = rot_Y_max;
                rotY_check = false;
                now_rotato = false;
                rot_check = false;
            }
        }
    }
}
