using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinEffect_ctr : MonoBehaviour
{
    float alpha;
    float scale;

    [HideInInspector] public bool effect_start;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0.0f;

        effect_start = false;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if(effect_start == true)
        {
            alpha = 0.8f;
        }
        else
        {
            SpinEffect();
        }

        if(alpha >= 0.8f)
        {
            effect_start = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    void SpinEffect()
    {
        alpha -= 3.0f * Time.deltaTime;
    }
}
