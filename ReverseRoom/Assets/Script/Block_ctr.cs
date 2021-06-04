using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(2 or -2)")]
    [SerializeField] int layer_number;

    GameObject parent;

    float white;

    float alpha;

    bool front_block_check;
    bool back_block_check;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("ReverseObject");
        transform.parent = parent.transform;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;

        alpha = 0.0f;

        front_block_check = false;
        back_block_check = false;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        Block();
    }

    void Block()
    {
        if(Player_ctr.game_over == true)
        {
            alpha = 0.0f;
        }
        if (Fade_ctr.fade == false)
        {
            alpha += 1.0f * Time.deltaTime;
        }

        if (Reverse_ctr.rot_check == true)
        {
            if (layer_number == 2 && front_block_check == false)
            {
                back_block_check = true;
            }
            if (layer_number == -2 && back_block_check == false)
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
            layer_number = 2;
        }
        if (back_block_check == true)
        {
            layer_number = -2;
        }

        if (layer_number == 2)
        {
            white = 1.0f;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (layer_number == -2)
        {
            white = 0.4f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;
    }
}
