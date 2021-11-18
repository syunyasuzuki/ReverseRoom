using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBlock_ctr : MonoBehaviour
{
    SpriteRenderer switch_image;

    [SerializeField] Sprite[] switch_on_off;

    AudioSource audio;
    [SerializeField] AudioClip switch_SE;

    int switch_number;

    float white;

    bool player_is_on;
    bool color_switch;

    [Header("TRUE：アクティブ　FALSE：非アクティブ")]
    public bool active_switch;

    // Start is called before the first frame update
    void Start()
    {
        switch_image = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        audio.clip = switch_SE;

        switch_number = 0;

        player_is_on = false;

        if(active_switch == true)
        {
            switch_number = 1;
        }
        else
        {
            switch_number = 0;
        }

        switch_image.sprite = switch_on_off[switch_number];
    }

    // Update is called once per frame
    void Update()
    {
        if(player_is_on == true)
        {
            if(active_switch == false)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    active_switch = true;
                    audio.Play();
                    switch_number = 1;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    active_switch = false;
                    audio.Play();
                    switch_number = 0;
                }
            }
        }
        switch_image.sprite = switch_on_off[switch_number];
    }

    void ColorBlinking()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player_is_on = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player_is_on = false;
        }
    }
}
