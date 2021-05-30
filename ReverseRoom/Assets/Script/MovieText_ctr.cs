using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieText_ctr : MonoBehaviour
{
    [SerializeField] Image movie_text;

    float time_count;

    float rot_Y;

    float alpha;

    bool text_open;
    bool text_close;

    // Start is called before the first frame update
    void Start()
    {
        time_count = 0.0f;
        rot_Y = 0.0f;
        alpha = 0.0f;

        text_open = false;
        text_close = false;

        movie_text.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        movie_text.rectTransform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time_count += 1.0f * Time.deltaTime;

        if(time_count >= 5.0f)
        {
            text_close = true;
        }

        if(Fade_ctr.fade == false && text_close == false)
        {
            text_open = true;
        }

        if (text_open)
        {
            TextOpen();
        }
        if (text_close)
        {
            TextClose();
        }
    }

    void TextOpen()
    {
        alpha += 1.0f * Time.deltaTime;
        rot_Y += 300.0f * Time.deltaTime;
        if(rot_Y >= 360.0f)
        {
            alpha = 1.5f;
            rot_Y = 360.0f;
            text_open = false;
        }

        movie_text.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        movie_text.rectTransform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }

    void TextClose()
    {
        alpha -= 1.0f * Time.deltaTime;
        rot_Y -= 300.0f * Time.deltaTime;
        if(rot_Y <= 0.0f)
        {
            rot_Y = 0.0f;
            text_close = false;
        }

        movie_text.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        movie_text.rectTransform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }
}
