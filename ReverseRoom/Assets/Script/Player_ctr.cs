using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctr : MonoBehaviour
{
    [Header("初期位置を指定")]
    [SerializeField] float start_pos_x;
    [SerializeField] float start_pos_y;

    float speed = 500;

    float move_x;

    float max_speed = 2.0f;

    Vector2 move;

    Rigidbody2D rg2D;

    bool move_check;

    // Start is called before the first frame update
    void Start()
    {
        move_check = true;

        rg2D = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(start_pos_x, start_pos_y);
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

    private void Move()
    {
        float speed_x = Mathf.Abs(rg2D.velocity.x);

        move = new Vector2(move_x * speed * Time.deltaTime, 0.0f);

        if (speed_x < max_speed)
        {
            rg2D.AddForce(move);
        }
    }
}
