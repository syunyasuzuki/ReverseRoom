using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(3 or -3)")]
    [SerializeField] int layer_number;

    Animator anima;

    GameObject parent;
    GameObject switch_block;

    float white;
    float alpha;
    float start_alpha;

    bool start;

    bool front_block_check;
    bool back_block_check;

    // Start is called before the first frame update
    void Start()
    {
        switch_block = GameObject.FindGameObjectWithTag("SwitchBlock");

        parent = GameObject.FindGameObjectWithTag("ReverseObject");
        transform.parent = parent.transform;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;

        anima = GetComponent<Animator>();

        alpha = 0.0f;
        if(switch_block.GetComponent<SwitchBlock_ctr>().active_switch == true)
        {
            start_alpha = 1.0f;
        }
        else
        {
            start_alpha = 0.4f;
        }

        if(layer_number == 3)
        {
            white = 1.0f;
        }
        else if(layer_number == -3)
        {
            white = 0.4f;
        }

        start = false;

        front_block_check = false;
        back_block_check = false;

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
            if (alpha < start_alpha)
            {
                alpha += Time.deltaTime;
            }
            else if(alpha >= start_alpha)
            {
                start = true;
            }
        }

        if(start == true && Player_ctr.game_over == false)
        {
            if (switch_block.GetComponent<SwitchBlock_ctr>().active_switch == true)
            {
                Block();
                alpha = 1.0f;
                transform.parent = parent.transform;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                alpha = 0.4f;
                transform.parent = null;
            }
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
    }

    void ColorBlink()
    {

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