using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_ctr : MonoBehaviour
{
    GameObject goal;
    GameObject dead_point;

    Rigidbody2D rg2D;

    Animator anima;

    AudioSource audio;
    [SerializeField] AudioClip walk_se;
    [SerializeField] AudioClip dead_se;

    string now_scene;

    float speed_x;
    float speed = 1000;
    float move_x;
    float max_speed = 4.0f;
    Vector2 move;
    float jump;
    float jump_Force = 460;

    float sleep_count;
    float walk_count;
    const float sleep_time = 30.0f;

    Vector3 chase;

    float rot_X;
    float alpha;
    const float invoke_time = 0.5f;

    bool move_check;
    bool animation_check;
    bool now_sleep;
    bool player_goal;

    public static bool key_get;
    public static bool game_over;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Door");
        dead_point = GameObject.FindGameObjectWithTag("DeadPoint");

        now_scene = SceneManager.GetActiveScene().name;

        player_goal = false;

        move_check = true;
        now_sleep = false;

        game_over = false;
        key_get = false;

        rg2D = GetComponent<Rigidbody2D>();

        anima = GetComponent<Animator>();

        audio = GetComponent<AudioSource>();
        audio.clip = walk_se;

        rot_X = 0.0f;
        alpha = 1.0f;

        if(now_scene == "TitleScene")
        {
            animation_check = false;
        }
        else
        {
            animation_check = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(now_scene == "TitleScene")
        {
            TitlePlayer();
            PlayerAnimation();
        }
        else
        {
            if(dead_point.GetComponent<DeadPoint_ctr>().player_dead == true)
            {
                GetComponent<BoxCollider2D>().isTrigger = true;
                if(Camera_ctr.size_change == false)
                {
                    game_over = true;
                    move_check = false;
                    Invoke(nameof(PlayerDead), invoke_time);
                }
            }
            else
            {
                GetComponent<BoxCollider2D>().isTrigger = false;
            }

            if (player_goal == true)
            {
                move_check = false;
                ClearMove();
            }

            if(animation_check == true)
            {
                PlayerAnimation();
            }

            if (move_check == true)
            {
                Move();
            }
            else
            {
                rg2D.isKinematic = true;
                rg2D.velocity = Vector2.zero;
            }

            if (Camera_ctr.size_change == true)
            {
                anima.SetFloat("WalkFloat", 0.0f);
                move_check = false;
                animation_check = false;
            }
            if (Camera_ctr.size_change == false && now_sleep == false)
            {
                if(dead_point.GetComponent<DeadPoint_ctr>().player_dead == true)
                {
                    audio.clip = dead_se;

                    animation_check = true;
                }
                else
                {
                    audio.clip = walk_se;

                    move_check = true;
                    animation_check = true;
                }
            }
        }
    }

    void Move()
    {
        rg2D.isKinematic = false;

        // 左右移動の処理
        move_x = Input.GetAxisRaw("Horizontal");

        move = new Vector2(move_x * speed * Time.deltaTime, 0.0f);

        speed_x = Mathf.Abs(rg2D.velocity.x);

        if (speed_x < max_speed)
        {
            rg2D.AddForce(move);
        }

        if(speed_x >= 0.1f && jump <= 0.01)
        {
            walk_count += 1.0f * Time.deltaTime;
        }
        if(walk_count >= 0.18f)
        {
            audio.Play();
            walk_count = 0.0f;
        }

        // ジャンプの処理
        jump = Mathf.Abs(rg2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && jump <= 0.01)
        {
            audio.Play();
            rg2D.AddForce(transform.up * jump_Force);
        }
    }

    void PlayerAnimation()
    {
        if(dead_point.GetComponent<DeadPoint_ctr>().player_dead == true)
        {
            anima.SetTrigger("DeadTrigger");
        }
        else
        {
            anima.SetTrigger("WaitTrigger");
        }

        if (speed_x <= 0.01f && jump <= 0.01f)
        {
            sleep_count += 1.0f * Time.deltaTime;
        }
        if (Input.anyKeyDown)
        {
            anima.SetFloat("SleepFloat", 0.0f);
            sleep_count = 0.0f;
        }

        if (jump > 0.01f)
        {
            anima.SetFloat("JumpFloat", jump);
        }
        else
        {
            anima.SetFloat("JumpFloat", 0.0f);
        }

        if (sleep_count >= sleep_time)
        {
            now_sleep = true;
            move_check = false;
            anima.SetFloat("SleepFloat", sleep_count);
        }

        if (speed_x > 0.1f)
        {
            anima.SetFloat("WalkFloat", speed_x);
        }
        else
        {
            anima.SetFloat("WalkFloat", 0.0f);
        }

        if (anima.GetCurrentAnimatorStateInfo(0).IsName("Player_Wait"))
        {
            now_sleep = false;
            move_check = true;
        }

        //プレイヤーの向きを変える
        if (move_x != 0)
        {
            transform.localScale = new Vector3(move_x, 1, 1);
        }
    }

    void TitlePlayer()
    {
        rg2D.isKinematic = true;
        jump = Mathf.Abs(rg2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animation_check = true;
        }

        if (Reverse_ctr.rot_check == true)
        {
            rg2D.isKinematic = false;
        }
    }

    void PlayerDead()
    {
        if(rot_X <= 0.0f)
        {
            audio.Play();
        }
        if (rot_X >= -90.0f)
        {
            rot_X -= 100.0f * Time.deltaTime;
        }
        if(rot_X < -90.0f)
        {
            alpha = 0.0f;
        }
        if(alpha <= 0.0f)
        {
            Fade_ctr.fade = true;
            Fade_ctr.fade_out = true;
            Invoke(nameof(Retry), invoke_time);
        }
        transform.eulerAngles = new Vector3(rot_X, 0.0f, 0.0f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    void ClearMove()
    {
        float pos_x;
        float pos_y;

        chase += (goal.transform.position - transform.position) * 4.0f;
        chase *= 0.5f;
        transform.position += chase * Time.deltaTime;

        pos_x = Mathf.Abs(goal.transform.position.x - transform.position.x);
        pos_y = Mathf.Abs(goal.transform.position.y - transform.position.y);

        if(pos_x <= 0.1 && pos_y <= 0.1)
        {
            alpha -= 1.0f * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
            if(alpha <= 0.0f && alpha >= -0.05f)
            {
                ClearManager.clear_check = true;
            }
        }
    }

    void Retry()
    {
        game_over = false;
        dead_point.GetComponent<DeadPoint_ctr>().player_dead = false;
        SceneManager.LoadScene(now_scene);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Key")
        {
            key_get = true;
        }
        if (col.gameObject.tag == "DeadLine")
        {
            Fade_ctr.fade = true;
            Fade_ctr.fade_out = true;
            Invoke(nameof(Retry), invoke_time);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Door")
        {
            if (key_get == true)
            {
                player_goal = true;
            }
        }
    }
}
