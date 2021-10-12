using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint_ctr : MonoBehaviour
{
    GameObject warp1;
    GameObject warp2;

    AudioSource audio;
    [SerializeField] AudioClip warp_SE;

    string my_name;

    float white;
    float alpha;

    const float blinking_speed = 1.0f;

    bool color_switch;
    bool player_touch;
    bool block_touch;

    public bool warp_se_ON;

    [HideInInspector] public bool now_warp;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = warp_SE;

        player_touch = false;

        color_switch = true;

        now_warp = false;

        alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Blinking();

        if (Camera_ctr.size_change == true || block_touch == true)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }


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
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player_touch = true;
        }
        if(col.gameObject.tag == "Block")
        {
            block_touch = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player_touch = false;
        }
        if(col.gameObject.tag == "Block")
        {
            block_touch = false;
        }
    }
}
