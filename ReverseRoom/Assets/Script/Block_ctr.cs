using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(1 or -1)")]
    [SerializeField] int layer_number;

    GameObject parent;

    float white;

    bool front_block_check;
    bool back_block_check;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("ReverseObject");
        transform.parent = parent.transform;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;

        front_block_check = false;
        back_block_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Reverse_ctr.rot_check == true)
        {
            if(layer_number == 1 && front_block_check == false)
            {
                back_block_check = true;
            }
            if(layer_number == -1 && back_block_check == false)
            {
                front_block_check = true;
            }
        }

        if(Reverse_ctr.rot_check == false)
        {
            back_block_check = false;
            front_block_check = false;
        }

        if (front_block_check == true)
        {
            layer_number = 1;
        }
        if (back_block_check == true)
        {
            layer_number = -1;
        }

        Block();
    }

    void Block()
    {
        if (layer_number == 1)
        {
            white = 1.0f;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        if (layer_number == -1)
        {
            white = 0.4f;
            GetComponent<BoxCollider2D>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;
    }
}
