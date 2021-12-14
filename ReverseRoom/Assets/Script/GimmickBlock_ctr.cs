using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(3 or -3)")]
    [SerializeField] int layer_number;

    SpriteRenderer gimmick_block_image;

    [SerializeField] Sprite[] gimmick_on_off;

    GameObject parent;
    GameObject switch_block;

    int gimmick_number;

    float white;
    float alpha;
    float blink;
    const float blink_speed = 0.3f;
    float start_alpha;

    bool gimmick_start;
    bool color_switch;

    bool front_block_check;
    bool back_block_check;

    // Start is called before the first frame update
    void Start()
    {
        switch_block = GameObject.FindGameObjectWithTag("SwitchBlock");

        parent = GameObject.FindGameObjectWithTag("ReverseObject");
        transform.parent = parent.transform;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;

        gimmick_block_image = GetComponent<SpriteRenderer>();

        alpha = 1.0f;

        if(switch_block.GetComponent<SwitchBlock_ctr>().active_switch == true)
        {
            gimmick_number = 1;
        }
        else
        {
            gimmick_number = 0;
        }

        if(layer_number == 3)
        {
            white = 1.0f;
        }
        else if(layer_number == -3)
        {
            white = 0.4f;
        }

        gimmick_start = false;

        front_block_check = false;
        back_block_check = false;

        gimmick_block_image.sprite = gimmick_on_off[gimmick_number];
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (Fade_ctr.fade == false)
        {
            if (Player_ctr.game_over == true)
            {
                alpha = 0.0f;
            }
            if (alpha < 1.0f)
            {
                alpha += Time.deltaTime;
            }
            else if(alpha >= 1.0f)
            {
                gimmick_start = true;
            }
        }

        if(gimmick_start == true && Player_ctr.game_over == false)
        {
            if (switch_block.GetComponent<SwitchBlock_ctr>().active_switch == true)
            {
                Block();
                gimmick_number = 1;
                transform.parent = parent.transform;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gimmick_number = 0;
                transform.parent = null;
            }
        }

        gimmick_block_image.sprite = gimmick_on_off[gimmick_number];
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
    }

    void ColorBlink()
    {
        if(color_switch == true)
        {
            blink -= blink_speed * Time.deltaTime;
            if(blink <= -0.2f)
            {
                color_switch = false;
            }
        }
        else
        {
            blink += blink_speed * Time.deltaTime;
            if(blink >= 0.0f)
            {
                color_switch = true;
            }
        }
    }

    void Block()
    {
        if (Reverse_ctr.rot_check == true)
        {
            if (layer_number == 3 && front_block_check == false)
            {
                back_block_check = true;
            }
            if (layer_number == -3 && back_block_check == false)
            {
                front_block_check = true;
            }
        }

        if (Reverse_ctr.rot_check == false)
        {
            back_block_check = false;
            front_block_check = false;
        }

        if (front_block_check == true)
        {
            layer_number = 3;
        }
        if (back_block_check == true)
        {
            layer_number = -3;
        }

        if (layer_number == 3)
        {
            white = 1.0f;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (layer_number == -3)
        {
            white = 0.4f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;
    }
}