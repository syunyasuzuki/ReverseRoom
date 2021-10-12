﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_ctr : MonoBehaviour
{
    [SerializeField] Image fade_Image;


    string now_scene;

    float alpha;

    float rot_Z;
    float rot_Y;

    public static bool fade;
    public static bool fade_in;
    public static bool fade_out;

    // Start is called before the first frame update
    void Start()
    {
        now_scene = SceneManager.GetActiveScene().name;

        alpha = 1.0f;

        fade = true;
        fade_in = true;
        fade_out = false;

        fade_Image.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if(fade == true)
        {
            fade_Image.enabled = true;
            if(fade_in == true)
            {
                FadeIn();
            }
            if(fade_out == true)
            {
                FadeOut();
            }
        }
    }

    void FadeIn()
    {
        rot_Z += 200.0f * Time.deltaTime;
        if(rot_Z >= 90.0f)
        {
            rot_Z = 90.0f;
            alpha -= 2.5f * Time.deltaTime;
            if (alpha <= 0.0f)
            {
                rot_Z = 0.0f;
                fade_Image.enabled = false;
                fade = false;
                fade_in = false;
            }
        }

        fade_Image.rectTransform.eulerAngles = new Vector3(0.0f, 0.0f, rot_Z);
        fade_Image.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    void FadeOut()
    {
        alpha += 2.5f * Time.deltaTime;
        if (alpha >= 1.0f)
        {
            if(now_scene == "CreditScene")
            {
                SceneManager.LoadScene("TitleScene");
            }
            fade = false;
            fade_out = false;
        }
        fade_Image.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    void FadeIn2()
    {
        fade_Image.rectTransform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
        fade_Image.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
    void FadeOut2()
    {
        fade_Image.rectTransform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
        fade_Image.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
