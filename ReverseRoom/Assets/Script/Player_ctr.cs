﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctr : MonoBehaviour
{
    Rigidbody2D rg2D;

    Animator anima;

    float speed_x;
    float speed = 500;
    float max_speed = 3.0f;

    float sleep_count;

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

        Player_Animation();

        if(move_check == true)
        {
            Move();
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

        if (move_x != 0)
        {
            transform.localScale = new Vector3(move_x, 1, 1);
        }
    }

    void Move()
    {
        move_x = Input.GetAxisRaw("Horizontal");

        speed_x = Mathf.Abs(rg2D.velocity.x);

        move = new Vector2(move_x * speed * Time.deltaTime, 0.0f);

        if (speed_x < max_speed)
        {
            rg2D.AddForce(move);
        }
    }

    void Player_Animation()
    {
        if (speed_x > 0.1f)
        {
            anima.SetFloat("WalkFloat", speed_x);
        }
        else
        {
            anima.SetFloat("WalkFloat", 0.0f);
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
