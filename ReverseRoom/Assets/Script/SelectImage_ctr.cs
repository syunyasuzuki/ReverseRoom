using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectImage_ctr : MonoBehaviour
{
    AudioSource audio;

    SpriteRenderer select_sprite;

    [SerializeField] Image left_arrow;
    [SerializeField] Image right_arrow;
    [SerializeField] GameObject warp1;
    [SerializeField] GameObject warp2;

    [SerializeField] Sprite[] select;
    [SerializeField] Button[] button_list;

    int select_number = 0;
    int max_number = 14;

    float rot_Y;

    float left_alpha;
    float right_alpha;

    bool number_up;
    bool number_down;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        select_sprite = gameObject.GetComponent<SpriteRenderer>();

        select_sprite.sprite = select[select_number];

        rot_Y = 0.0f;

        left_alpha = 0.0f;
        right_alpha = 1.0f;

        warp1.SetActive(false);
        warp2.SetActive(false);

        number_up = false;
        number_down = false;

        left_arrow.color = new Color(1.0f, 1.0f, 1.0f, left_alpha);
        right_arrow.color = new Color(1.0f, 1.0f, 1.0f, right_alpha);
    }

    // Update is called once per frame
    void Update()
    {
        SelectRotate();
        ArrowImage();
    }

    void SelectRotate()
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

        if(number_up == true)
        {
            rot_Y += 600.0f * Time.deltaTime;
            if(rot_Y >= 360.0f)
            {
                audio.Play();
                GimmickImage();
                rot_Y = 0.0f;
                number_up = false;
            }
        }
        if(number_down == true)
        {
            rot_Y -= 600.0f * Time.deltaTime;
            if(rot_Y <= -360.0f)
            {
                audio.Play();
                GimmickImage();
                rot_Y = 0.0f;
                number_down = false;
            }
        }

        if(rot_Y >= 260.0f && rot_Y <= 280.0f)
        {
            select_sprite.sprite = select[select_number];
        }
        if(rot_Y <= -260.0f && rot_Y >= -280.0f)
        {
            select_sprite.sprite = select[select_number];
        }
        button_list[select_number].Select();
        gameObject.transform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }

    void ArrowImage()
    {
        if(select_number == 0 || number_down == true || number_up == true)
        {
            left_alpha = 0.0f;
        }
        else
        {
            left_alpha = 1.0f;
        }

        if(select_number == max_number || number_down == true || number_up == true)
        {
            right_alpha = 0.0f;
        }
        else
        {
            right_alpha = 1.0f;
        }
        left_arrow.color = new Color(1.0f, 1.0f, 1.0f, left_alpha);
        right_arrow.color = new Color(1.0f, 1.0f, 1.0f, right_alpha);
    }

    void GimmickImage()
    {
        if(select_number >= 12)
        {
            warp1.SetActive(true);
            warp2.SetActive(true);
        }
        else
        {
            warp1.SetActive(false);
            warp2.SetActive(false);
        }
    }
}
