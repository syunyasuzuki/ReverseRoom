using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPoint_R_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(6 or -6)")]
    public int layer_number = 6;

    GameObject parent;

    new AudioSource audio;
    [SerializeField] AudioClip warp_SE;

    string now_scene;

    float white;
    float alpha;

    const float blinking_speed = 1.0f;

    bool color_switch;
    bool player_touch;

    bool front_warp_check;
    bool back_warp_check;

    [HideInInspector] public bool warp_se_ON;

    [HideInInspector] public bool now_warp;

    // Start is called before the first frame update
    void Start()
    {
        now_scene = SceneManager.GetActiveScene().name;

        parent = GameObject.FindGameObjectWithTag("ReverseObject");
        transform.parent = parent.transform;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;

        audio = GetComponent<AudioSource>();
        audio.clip = warp_SE;

        player_touch = false;

        color_switch = true;

        now_warp = false;
    }

    // Update is called once per frame
    void Update()
    {
        WarpSE();
        WarpReverse();
        //Blinking();

        if (Camera_ctr.size_change == true)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void WarpSE()
    {
        if (now_warp == true)
        {
            if (warp_se_ON == true)
            {
                audio.Play();
                warp_se_ON = false;
            }
        }
        else
        {
            if (player_touch == true)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    now_warp = true;
                }
            }
            warp_se_ON = true;
        }
    }

    void WarpReverse()
    {
        if (Reverse_ctr.rot_check == true)
        {
            if (layer_number == 6 && front_warp_check == false)
            {
                back_warp_check = true;
            }
            if (layer_number == -6 && back_warp_check == false)
            {
                front_warp_check = true;
            }
        }
        else
        {
            back_warp_check = false;
            front_warp_check = false;
        }

        if (front_warp_check == true)
        {
            layer_number = 6;
        }
        if (back_warp_check == true)
        {
            layer_number = -6;
        }

        if (layer_number == 6)
        {
            white = 1.0f;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (layer_number == -6)
        {
            white = 0.3f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;
    }

    void Blinking()
    {
        if (color_switch == true)
        {
            white -= blinking_speed * Time.deltaTime;
            if (white <= 0.5f)
            {
                color_switch = false;
            }
        }
        if (color_switch == false)
        {
            white += blinking_speed * Time.deltaTime;
            if (white >= 1.0f)
            {
                color_switch = true;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player_touch = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player_touch = false;
        }
    }
}
