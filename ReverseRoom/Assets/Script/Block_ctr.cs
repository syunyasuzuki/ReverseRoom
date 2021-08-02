using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(2 or -2)")]
    [SerializeField] int layer_number;

    [Header("回転するブロックかどうか？")]
    [SerializeField] bool spin_block = false;

    GameObject player;

    GameObject parent;

    float white;
    float alpha;

    float rot_z;
    float rot_Z_max = 90.0f;
    bool rot_z_check;

    bool front_block_check;
    bool back_block_check;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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

        if (spin_block == true && Camera_ctr.size_change == false)
        {
            if(Player_ctr.now_jump == false && Input.GetKeyDown(KeyCode.Space))
            {
                rot_z_check = true;
            }
            SpinBlockZ();
        }
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

    void SpinBlockZ()
    {
        if (rot_z_check == true)
        {
            if (rot_z >= 90.0f)
            {
                rot_Z_max = 180.0f;
            }
            if (rot_z >= 180.0f)
            {
                rot_Z_max = 270.0f;
            }
            if (rot_z >= 270.0f)
            {
                rot_Z_max = 360f;
            }
            if (rot_z >= 360.0f)
            {
                rot_Z_max = 90.0f;
                rot_z = 0.0f;
            }
            rot_z += 500.0f * Time.deltaTime;
            if (rot_z >= rot_Z_max)
            {
                rot_z = rot_Z_max;
                rot_z_check = false;
            }
        }
        transform.eulerAngles = new Vector3(0.0f, 0.0f, rot_z);
    }
}
