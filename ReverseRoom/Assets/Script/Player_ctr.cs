using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_ctr : MonoBehaviour
{
    GameObject goal;

    GameObject warp_point1;
    GameObject warp_point2;

    GameObject dead_point;

    Rigidbody2D rg2D;

    Animator anima;

    AudioSource audio;
    [SerializeField] AudioClip walk_se;

    string now_scene;

    float speed_x;
    float speed = 1000;
    float move_x;
    float max_speed = 4.0f;
    Vector2 move;
    float jump;
    float jump_Force = 460;

    float sleep_count;
    float blink_count;
    float walk_count;
    const float blink_time = 7.0f;
    const float sleep_time = 45.0f;

    float warp_count = 0;

    float warp_point1_x;
    float warp_point1_y;
    float warp_point2_x;
    float warp_point2_y;

    Vector3 chase;

    float rot_X;
    float rot_Y;
    float alpha;
    const float invoke_time = 0.5f;

    bool move_check;
    bool now_sleep;
    bool player_goal;
    bool warp_check1;
    bool warp_check2;

    bool warp_start1;
    bool warp_start2;

    public static bool now_jump;

    public static bool key_get;
    public static bool game_over;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Door");
        warp_point1 = GameObject.FindGameObjectWithTag("WarpPoint");
        warp_point2 = GameObject.FindGameObjectWithTag("WarpPoint2");
        dead_point = GameObject.FindGameObjectWithTag("DeadPoint");

        now_scene = SceneManager.GetActiveScene().name;

        player_goal = false;

        move_check = true;
        now_sleep = false;
        now_jump = false;

        game_over = false;
        key_get = false;

        rg2D = GetComponent<Rigidbody2D>();
        var material = GetComponent<Rigidbody2D>().sharedMaterial;

        anima = GetComponent<Animator>();

        audio = GetComponent<AudioSource>();
        audio.clip = walk_se;

        rot_X = 0.0f;
        alpha = 1.0f;

        if(warp_point1 == null)
        {

        }
        else
        {
            warp_point1_x = warp_point1.transform.position.x;
            warp_point1_y = warp_point1.transform.position.y;
            warp_point2_x = warp_point2.transform.position.x;
            warp_point2_y = warp_point2.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(now_scene == "TitleScene" || now_scene == "SelectScene")
        {
            TitleMove();
            if(warp_count < 1.2f)
            {
                warp_count += Time.deltaTime;
            }
            if (warp_count >= 1.2f)
            {
                if (warp_check2 == false && warp_check1 == true)
                {
                    warp_point2.GetComponent<WarpPoint_ctr>().now_warp = false;
                    PlayerWarp1();
                }
                if (warp_check1 == false && warp_check2 == true)
                {
                    warp_point1.GetComponent<WarpPoint_ctr>().now_warp = false;
                    PlayerWarp2();
                }
            }
        }
        else
        {
            if(Button_ctr.now_button_select == true)
            {
                move_check = false;
            }
            else
            {
                if (Reverse_ctr.now_rotato == false && dead_point.GetComponent<DeadPoint_ctr>().player_dead == true)
                {
                    anima.SetFloat("PanicFloat", 1.0f);
                    GetComponent<BoxCollider2D>().isTrigger = true;
                    if (Camera_ctr.size_change == false)
                    {
                        game_over = true;
                    }
                }
                else
                {
                    anima.SetFloat("PanicFloat", 0.0f);
                    GetComponent<BoxCollider2D>().isTrigger = false;
                }

                if (Camera_ctr.size_change == true)
                {
                    move_check = false;
                    anima.SetFloat("JumpFloat", 0.0f);
                    anima.SetFloat("WalkFloat", 0.0f);
                }
                if (Camera_ctr.size_change == false && now_sleep == false)
                {
                    move_check = true;
                }

                if (player_goal == true)
                {
                    move_check = false;
                    ClearMove();
                }

                if (game_over == true)
                {
                    anima.SetTrigger("DeadTrigger");
                    move_check = false;
                    GetComponent<BoxCollider2D>().enabled = false;
                    Invoke(nameof(PlayerDead), invoke_time);
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

                if(warp_check2 == false && warp_check1 == true)
                {
                    warp_point2.GetComponent<WarpPoint_ctr>().now_warp = false;
                    PlayerWarp1();
                }

                if (warp_check1 == false && warp_check2 == true)
                {
                    warp_point1.GetComponent<WarpPoint_ctr>().now_warp = false;
                    PlayerWarp2();
                }

                if (now_sleep == true)
                {
                    move_check = false;
                    PlayerSleep();
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

        // X軸に変化があればウォークアニメーション起動
        if (speed_x > 0.1f)
        {
            anima.SetFloat("WalkFloat", speed_x);
        }
        else
        {
            anima.SetFloat("WalkFloat", 0.0f);
        }

        if (speed_x >= 0.1f && jump <= 0.01)
        {
            walk_count += 1.0f * Time.deltaTime;
        }
        if (walk_count >= 0.18f)
        {
            audio.Play();
            walk_count = 0.0f;
        }

        //プレイヤーの向きを変える
        if (move_x != 0)
        {
            transform.localScale = new Vector3(move_x, 1, 1);
        }

        // ジャンプの処理
        jump = Mathf.Abs(rg2D.velocity.y);

        if (now_jump == false && Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
            rg2D.AddForce(transform.up * jump_Force);
        }

        // Y軸の値に変化があったらジャンプアニメーション起動
        if (jump > 0.01f)
        {
            now_jump = true;
            anima.SetFloat("JumpFloat", jump);
        }
        else
        {
            now_jump = false;
            anima.SetFloat("JumpFloat", 0.0f);
        }

        if (speed_x <= 0.01f && jump <= 0.01f)
        {
            blink_count += Time.deltaTime;
            sleep_count += Time.deltaTime;
        }
        else
        {
            blink_count = 0.0f;
            sleep_count = 0.0f;
        }

        if(blink_count >= blink_time)
        {
            anima.SetFloat("BlinkFloat", blink_time);
            if(blink_count >= 7.1)
            {
                anima.SetFloat("BlinkFloat", 0.0f);
                blink_count = 0.0f;
            }
        }

        if(sleep_count >= sleep_time)
        {
            now_sleep = true;
        }
    }

    void PlayerWarp1()
    {
        rg2D.isKinematic = true;
        rg2D.velocity = Vector2.zero;

        if (transform.position.x != warp_point2_x || transform.position.y != warp_point2_y)
        {
            rot_Y += 300.0f * Time.deltaTime;
        }
        if (rot_Y >= 90.0f)
        {
            if (now_scene == "SelectScene")
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            transform.position = new Vector3(warp_point2_x, warp_point2_y);
        }
        if (transform.position.x == warp_point2_x && transform.position.y == warp_point2_y)
        {
            rot_Y -= 300.0f * Time.deltaTime;
            if(rot_Y <= 0.0f)
            {
                if (now_scene == "SelectScene")
                {
                    warp_count = 0.0f;
                }
                rot_Y = 0.0f;
                warp_point1.GetComponent<WarpPoint_ctr>().now_warp = false;
                warp_point2.GetComponent<WarpPoint_ctr>().now_warp = false;
                warp_check1 = false;
            }
        }
        transform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }

    void PlayerWarp2()
    {
        rg2D.isKinematic = true;
        rg2D.velocity = Vector2.zero;

        if (transform.position.x != warp_point1_x || transform.position.y != warp_point1_y)
        {
            rot_Y += 300.0f * Time.deltaTime;
        }
        if (rot_Y >= 90.0f)
        {
            if(now_scene == "SelectScene")
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            transform.position = new Vector3(warp_point1_x, warp_point1_y);
        }
        if(transform.position.x == warp_point1_x && transform.position.y == warp_point1_y)
        {
            rot_Y -= 300.0f * Time.deltaTime;
            if(rot_Y <= 0.0f)
            {
                if (now_scene == "SelectScene")
                {
                    warp_count = 0.0f;
                }
                rot_Y = 0.0f;
                warp_point1.GetComponent<WarpPoint_ctr>().now_warp = false;
                warp_point2.GetComponent<WarpPoint_ctr>().now_warp = false;
                warp_check2 = false;
            }
        }
        transform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }

    void PlayerSleep()
    {
        anima.SetFloat("SleepFloat", sleep_count);

        if (Input.anyKeyDown)
        {
            sleep_count = 0.0f;
            anima.SetFloat("SleepFloat", 0.0f);
        }

        if (anima.GetCurrentAnimatorStateInfo(0).IsName("Player_Wait"))
        {
            now_sleep = false;
        }
    }

    void TitleMove()
    {
        rg2D.isKinematic = true;
        jump = Mathf.Abs(rg2D.velocity.y);
        blink_count += Time.deltaTime;

        if (blink_count >= blink_time)
        {
            anima.SetFloat("BlinkFloat", blink_time);
            if (blink_count >= 7.1)
            {
                anima.SetFloat("BlinkFloat", 0.0f);
                blink_count = 0.0f;
            }
        }

        if (Reverse_ctr.rot_check == true)
        {
            anima.SetFloat("JumpFloat", jump);
            rg2D.isKinematic = false;
        }
    }

    void PlayerDead()
    {
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
                Button_ctr.now_button_select = true;
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

    void OnTriggerStay2D(Collider2D col)
    {
        if(now_scene == "SelectScene")
        {
            if (col.gameObject.tag == "WarpPoint")
            {
                if (warp_check2 == false)
                {
                    warp_check1 = true;
                }
            }
            if (col.gameObject.tag == "WarpPoint2")
            {
                if (warp_check1 == false)
                {
                    warp_check2 = true;
                }
            }
        }
        else
        {
            if (col.gameObject.tag == "WarpPoint")
            {
                if (warp_check2 == false)
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        warp_check1 = true;
                    }
                }
            }
            if (col.gameObject.tag == "WarpPoint2")
            {
                if (warp_check1 == false)
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        warp_check2 = true;
                    }
                }
            }
        }
    }
}
