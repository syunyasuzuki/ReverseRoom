using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_ctr : MonoBehaviour
{
    float white;

    bool color_switch;

    // Start is called before the first frame update
    void Start()
    {
        white = 1.0f;
        color_switch = true;
    }

    // Update is called once per frame
    void Update()
    {
        LogoBlinking();
    }

    void LogoBlinking()
    {
        if (color_switch == true)
        {
            white -= 0.8f * Time.deltaTime;
            if (white <= 0.3f)
            {
                color_switch = false;
            }
        }
        if (color_switch == false)
        {
            white += 0.8f * Time.deltaTime;
            if (white >= 1.0f)
            {
                color_switch = true;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
    }
}
