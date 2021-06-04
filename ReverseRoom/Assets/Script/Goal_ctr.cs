using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_ctr : MonoBehaviour
{
    Animator anima;

    float goal_rotato;

    float white;
    float alpha;

    public static bool goal_open;
    bool color_switch;

    // Use this for initialization
    void Start()
    {
        alpha = 1.0f;
        white = 1.0f;
        goal_open = false;
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_ctr.game_over == true)
        {
            alpha = 0.0f;
        }

        if(Camera_ctr.size_change == true)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }

        if (goal_open == true)
        {
            anima.SetTrigger("OpenTrigger");
            GoalOpen();
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
    }

    void GoalOpen()
    {
        goal_rotato = Mathf.Clamp(goal_rotato + Time.deltaTime * 300, 0, 180);

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

        transform.eulerAngles = new Vector3(0.0f, 0.0f, goal_rotato);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, alpha);
    }
}
