using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNumber_ctr : MonoBehaviour
{
    SpriteRenderer number_sprite;

    [SerializeField] Sprite[] number;

    int select_number = 0;
    // 選べるステージの最大値を決める
    int max_number = 16;

    float rot_Y;

    float left_alpha;
    float right_alpha;

    bool number_up;
    bool number_down;

    // Start is called before the first frame update
    void Start()
    {
        number_sprite = gameObject.GetComponent<SpriteRenderer>();

        number_sprite.sprite = number[select_number];

        rot_Y = 0.0f;

        left_alpha = 0.0f;
        right_alpha = 1.0f;

        number_up = false;
        number_down = false;
    }

    // Update is called once per frame
    void Update()
    {
        NumberRotate();
    }

    void NumberRotate()
    {
        if (number_down == false && number_up == false && select_number < max_number)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                select_number += 1;
                number_up = true;
            }
        }
        if (number_up == false && number_down == false && select_number > 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                select_number -= 1;
                number_down = true;
            }
        }

        if (number_up == true)
        {
            rot_Y += 600.0f * Time.deltaTime;
            if (rot_Y >= 360.0f)
            {
                rot_Y = 0.0f;
                number_up = false;
            }
        }
        if (number_down == true)
        {
            rot_Y -= 600.0f * Time.deltaTime;
            if (rot_Y <= -360.0f)
            {
                rot_Y = 0.0f;
                number_down = false;
            }
        }

        if (rot_Y >= 260.0f && rot_Y <= 280.0f)
        {
            number_sprite.sprite = number[select_number];
        }
        if (rot_Y <= -260.0f && rot_Y >= -280.0f)
        {
            number_sprite.sprite = number[select_number];
        }
        gameObject.transform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }
}
