using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_ctr : MonoBehaviour
{
    GameObject goal;

    Rigidbody2D rg2D;

    Vector3 chase;

    float rot_Y;

    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 1.0f;

        goal = GameObject.FindGameObjectWithTag("Door");

        rg2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_ctr.game_over == true)
        {
            alpha = 0.0f;
        }

        if (Camera_ctr.size_change == true)
        {
            rg2D.velocity = Vector2.zero;
            rg2D.isKinematic = true;
        }
        if (Camera_ctr.size_change == false)
        {
            rg2D.isKinematic = false;
        }

        if(Player_ctr.key_get == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            rg2D.isKinematic = true;
            rg2D.velocity = Vector2.zero;
            KeyMove();
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    void KeyMove()
    {
        float pos_x;
        float pos_y;

        rot_Y += 750.0f * Time.deltaTime;

        chase += (goal.transform.position - transform.position) * 4.0f;
        chase *= 0.45f;
        transform.position += chase * Time.deltaTime;

        pos_x = Mathf.Abs(goal.transform.position.x - transform.position.x);
        pos_y = Mathf.Abs(goal.transform.position.y - transform.position.y);

        if (pos_x <= 0.1 && pos_y <= 0.1)
        {
            rot_Y = 0.0f;
            alpha -= 5.0f * Time.deltaTime;
            if (alpha <= 0.0f)
            {
                Goal_ctr.goal_open = true;
            }
        }
        transform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }
}
