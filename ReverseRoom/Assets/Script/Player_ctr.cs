using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctr : MonoBehaviour
{
    Rigidbody2D rg2D;

    Animator anima;

    float speed_x;
    float speed = 1000;
    float jump;
    float jump_Force = 500;
    float max_speed = 4.0f;

    float sleep_count;
    float wait_count;

    float move_x;
    Vector2 move;

    bool move_check;

    public static bool key_get;

    // Start is called before the first frame update
    void Start()
    {
        move_check = true;

        key_get = false;

        rg2D = GetComponent<Rigidbody2D>();

        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move_check == true)
        {
            Move();
            Jump();
        }

        if (Camera_ctr.size_change == true)
        {
            anima.SetFloat("WalkFloat", 0.0f);
            anima.SetFloat("SleepFloat", 0.0f);
            rg2D.velocity = Vector2.zero;
            rg2D.isKinematic = true;
        }
        if (Camera_ctr.size_change == false)
        {
            Player_Animation();
            rg2D.isKinematic = false;
        }
    }

    void Move()
    {
        move_x = Input.GetAxisRaw("Horizontal");

        move = new Vector2(move_x * speed * Time.deltaTime, 0.0f);

        speed_x = Mathf.Abs(rg2D.velocity.x);

        if (speed_x < max_speed)
        {
            rg2D.AddForce(move);
        }
    }

    void Jump()
    {
        jump = Mathf.Abs(rg2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && rg2D.velocity.y == 0)
        {
            rg2D.AddForce(transform.up * jump_Force);
        }
    }

    void Player_Animation()
    {
        if(speed_x <= 0.01f && jump <= 0.01f)
        {
            sleep_count += 1.0f * Time.deltaTime;
        }
        if (Input.anyKeyDown)
        {
            anima.SetFloat("SleepFloat", 0.0f);
            sleep_count = 0.0f;
        }

        if (jump > 0.01f)
        {
            anima.SetFloat("JumpFloat", jump);
        }
        else
        {
            anima.SetFloat("JumpFloat", 0.0f);
        }

        if (sleep_count >= 15.0f)
        {
            anima.SetFloat("SleepFloat", sleep_count);
            move_check = false;
        }

        if (speed_x > 0.1f)
        {
            anima.SetFloat("WalkFloat", speed_x);
        }
        else
        {
            anima.SetFloat("WalkFloat", 0.0f);
        }

        if (anima.GetCurrentAnimatorStateInfo(0).IsName("Player_Wait"))
        {
            move_check = true;
        }

        //プレイヤーの向きを変える
        if (move_x != 0)
        {
            transform.localScale = new Vector3(move_x, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Key")
        {
            key_get = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Door")
        {
            if(key_get == true)
            {

            }
        }
    }
}
