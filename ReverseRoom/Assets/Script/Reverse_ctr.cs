using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reverse_ctr : MonoBehaviour
{
    GameObject spin_effect;

    Camera cam;

    AudioSource audio;
    [SerializeField] AudioClip reverse_SE;

    float alpha;

    float room_rotato_x;
    float room_rotato_y;
    float room_rotato_Z;
    float rot_Z_max = 90.0f;
    float rot_X_max = 180.0f;
    float rot_Y_max = 180.0f;

    bool effect_start;
    bool alpha_switch;

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
        spin_effect = GameObject.FindGameObjectWithTag("SpinEffect");

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
        if(ClearManager.clear_check == true)
        {
            return;
        }

        if (now_Scene == "TitleScene")
        {
            if(TitleManager.title_start == true)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if(title_reverse_check == false)
                    {
                        audio.Play();
                    }
                    title_reverse_check = true;
                }
            }
        }
        else
        {
            if (cam.orthographicSize >= 8.0f)
            {
                reverse_check = true;
            }
            else
            {
                reverse_check = false;
            }
        }

        if (reverse_check == true)
        {
            Reverse();
        }
        if(title_reverse_check == true)
        {
            TitleReverse();
        }
        transform.eulerAngles = new Vector3(room_rotato_x, room_rotato_y, room_rotato_Z);
    }

    void Reverse()
    {
        if (room_rotato_x >= 83.0f && room_rotato_x <= 97.0f)
        {
            rot_check = true;
        }
        if (room_rotato_y >= 83.0f && room_rotato_y <= 97.0f)
        {
            rot_check = true;
        }
        if (room_rotato_x >= 263.0f && room_rotato_x <= 277.0f)
        {
            rot_check = true;
        }
        if (room_rotato_y >= 263.0f && room_rotato_y <= 277.0f)
        {
            rot_check = true;
        }

        if (now_rotato == false && Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotY_check = true;
            now_rotato = true;
        }
        if (now_rotato == false && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotY_check = true;
            now_rotato = true;
        }
        if (now_rotato == false && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotX_check = true;
            now_rotato = true;
        }
        if (now_rotato == false && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotX_check = true;
            now_rotato = true;
        }
        if (now_rotato == false && Input.GetKeyDown(KeyCode.Space))
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
            room_rotato_y += 400 * Time.deltaTime;
            if(room_rotato_y >= rot_Y_max)
            {
                audio.Play();
                room_rotato_y = rot_Y_max;
                spin_effect.GetComponent<SpinEffect_ctr>().effect_start = true;
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
            room_rotato_x += 400 * Time.deltaTime;
            if (room_rotato_x >= rot_X_max)
            {
                audio.Play();
                room_rotato_x = rot_X_max;
                spin_effect.GetComponent<SpinEffect_ctr>().effect_start = true;
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
            room_rotato_Z += 250.0f * Time.deltaTime;
            if(room_rotato_Z >= rot_Z_max)
            {
                audio.Play();
                room_rotato_Z = rot_Z_max;
                spin_effect.GetComponent<SpinEffect_ctr>().effect_start = true;
                rotZ_check = false;
                now_rotato = false;
            }
        }
    }

    void TitleReverse()
    {
        if (room_rotato_y >= 85.0f && room_rotato_y <= 95.0f)
        {
            rot_check = true;
        }

        room_rotato_y = Mathf.Clamp(room_rotato_y + Time.deltaTime * 300, 0, 180);
    }
}
