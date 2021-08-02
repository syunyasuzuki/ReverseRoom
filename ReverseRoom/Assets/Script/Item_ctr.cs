using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ctr : MonoBehaviour
{
    Rigidbody2D rg2D;

    float white;

    bool color_switch;

    // Start is called before the first frame update
    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();

        color_switch = true;
        white = 1.0f;

        GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        NormalMove();
    }

    void NormalMove()
    {
        if (Camera_ctr.size_change == true)
        {
            rg2D.velocity = Vector2.zero;
            rg2D.isKinematic = true;
        }
        if (Camera_ctr.size_change == false)
        {
            rg2D.isKinematic = false;
        }

        if (color_switch == true)
        {
            white -= 0.5f * Time.deltaTime;
            if (white <= 0.3f)
            {
                color_switch = false;
            }
        }
        if (color_switch == false)
        {
            white += 0.5f * Time.deltaTime;
            if (white >= 1.0f)
            {
                color_switch = true;
            }
        }
        GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
    }
}
