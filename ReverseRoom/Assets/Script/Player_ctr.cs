using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctr : MonoBehaviour
{
    float speed = 500;

    float move_x;

    float max_speed = 3.0f;

    Vector2 move;

    Rigidbody2D rg2D;

    bool move_check;

    bool key_get;

    // Start is called before the first frame update
    void Start()
    {
        move_check = true;

        key_get = false;

        rg2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxisRaw("Horizontal");

        if(move_check == true)
        {
            Move();
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))
        {
            rg2D.velocity = Vector2.zero;
            rg2D.isKinematic = true;
        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.X))
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
        float speed_x = Mathf.Abs(rg2D.velocity.x);

        move = new Vector2(move_x * speed * Time.deltaTime, 0.0f);

        if (speed_x < max_speed)
        {
            rg2D.AddForce(move);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Key")
        {
            key_get = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Door")
        {
            if(key_get == true)
            {

            }
        }
    }
}
