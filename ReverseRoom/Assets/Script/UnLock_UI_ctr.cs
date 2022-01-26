using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLock_UI_ctr : MonoBehaviour
{
    Animator anima;

    float alpha;

    bool unlock_in;
    bool unlock_out;

    [SerializeField] AudioClip unlock_se;

    new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        unlock_in = false;
        unlock_out = false;

        alpha = 0.0f;
        anima = GetComponent<Animator>();
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

        audio = GetComponent<AudioSource>();
        audio.clip = unlock_se;
    }

    // Update is called once per frame
    void Update()
    {
        if (Goal_ctr.goal_open == true && unlock_out == false)
        {
            unlock_in = true;
        }

        if (unlock_in == true)
        {
            UnLock_In();
        }
        if (unlock_out == true)
        {
            Invoke(nameof(UnLock_Out), 0.7f);
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
    void UnLock_In()
    {
        if (alpha <= 0.6f)
        {
            alpha += 2.0f * Time.deltaTime;
        }
        if (alpha >= 0.6f)
        {
            audio.Play();
            anima.SetTrigger("UnLockTrigger");
            unlock_in = false;
            unlock_out = true;
        }
    }
    void UnLock_Out()
    {
        alpha -= 2.0f * Time.deltaTime;
        if(alpha <= 0.0f)
        {
            Goal_ctr.goal_open = false;
        }
    }
}
