using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    [SerializeField] GameObject m_Credit;
    [SerializeField] GameObject m_Thank_you;

    float credit_pos_y;
    float thank_alpha;

    // Start is called before the first frame update
    void Start()
    {
        credit_pos_y = -6.5f;
        thank_alpha = 0.0f;

        m_Credit.transform.position = new Vector3(0.0f, credit_pos_y, 0.0f);
        m_Thank_you.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, thank_alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (credit_pos_y <= 26.5f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                credit_pos_y += 5.0f * Time.deltaTime;
            }
            else
            {
                credit_pos_y += 1.0f * Time.deltaTime;
            }
        }
        if (credit_pos_y > 26.5f)
        {
            if (thank_alpha <= 3.0f)
            {
                thank_alpha += 1.0f * Time.deltaTime;
            }
            if(thank_alpha > 3.0f)
            {
                Fade_ctr.fade = true;
                Fade_ctr.fade_out = true;
            }
        }

        m_Credit.transform.position = new Vector3(0.0f, credit_pos_y, 0.0f);
        m_Thank_you.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, thank_alpha);
    }
}
