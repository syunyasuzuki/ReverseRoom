using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_ctr : MonoBehaviour
{
    Animator anima;

    GameObject parent;

    float goal_rotato;

    float white;

    bool goal_open;
    bool alpha_switch;

    // Use this for initialization
    void Start()
    {
        white = 1.0f;
        goal_open = false;
        anima = GetComponent<Animator>();

        parent = GameObject.FindGameObjectWithTag("ReverseObject");

        transform.parent = parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_ctr.key_get == true)
        {
            goal_open = true;
            anima.SetTrigger("OpenTrigger");
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
            GoalOpen();
        }
    }

    void GoalOpen()
    {
        goal_rotato = Mathf.Clamp(goal_rotato + Time.deltaTime * 200, 0, 180);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, goal_rotato);

        if (alpha_switch == true)
        {
            white -= 0.5f * Time.deltaTime;
            if (white <= 0.3f)
            {
                alpha_switch = false;
            }
        }
        if (alpha_switch == false)
        {
            white += 0.5f * Time.deltaTime;
            if (white >= 1.0f)
            {
                alpha_switch = true;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
    }
}
