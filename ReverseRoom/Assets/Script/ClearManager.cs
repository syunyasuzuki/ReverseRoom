using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearManager : Button_ctr
{
    //クリアしたかどうかを判定する変数
    public static bool clear_check;

    string now_scene;

    //メインカメラを取得する変数
    Camera cam;

    new AudioSource audio;

    //-----------クリアメニュー一覧を取得する変数たち-----------//
    [SerializeField] GameObject panel;
    [SerializeField] Image clear_Logo;
    [SerializeField] Image clear_Effect;
    [SerializeField] Image clear_menu;
    [SerializeField] Image next;
    [SerializeField] Image select;
    [SerializeField] Image retry;

    [SerializeField] Button List1;
    [SerializeField] Button List2;
    [SerializeField] Button List3;
    //-------------------------------------------------------//

    //クリアメニューの透明度を変える変数
    float alpha;

    float effect_scale;
    float effect_alpha;

    //クリアロゴのY軸移動に使う変数
    float pos_Y;

    float rot_Y;
    float logo_scale;

    float menu_rot_x;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();

        effect_alpha = 1.0f;
        effect_scale = 0.0f;

        rot_Y = 0.0f;
        logo_scale = 0.0f;

        pos_Y = 0.0f;

        menu_rot_x = -90.0f;

        //現在のシーン名取得
        now_scene = SceneManager.GetActiveScene().name;

        //パネルを非表示
        panel.SetActive(false);

        //メインカメラを取得
        cam = Camera.main;

        //クリアチェックの初期化
        clear_check = false;

        //クリアメニューアルファ値の初期化
        alpha = 0.0f;

        //上記値を反映
        clear_Logo.rectTransform.localPosition = new Vector3(0.0f, pos_Y, 0.0f);
        clear_menu.rectTransform.localPosition = new Vector3(0.0f, -70.0f, 0.0f);
        clear_menu.rectTransform.eulerAngles = new Vector3(menu_rot_x, 0.0f, 0.0f);
        next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        clear_Effect.color = new Color(1.0f, 1.0f, 1.0f, effect_alpha);
        clear_Effect.GetComponent<RectTransform>().localScale = new Vector3(effect_scale, effect_scale);
    }

    // Update is called once per frame
    void Update()
    {
        //クリアしていない場合
        if (clear_check == false)
        {

        }

        //クリアした場合
        if (clear_check == true)
        {
            //ゲームクリアメソッドを呼ぶ
            GameClear();
        }
    }

    /// <summary>
    /// ステージクリアしたら呼び出すメソッド
    /// </summary>
    void GameClear()
    {
        panel.SetActive(true);
        if(logo_scale <= 1.0f)
        {
            logo_scale += 1.0f * Time.deltaTime;
        }
        if(rot_Y < 360.0f)
        {
            rot_Y += 450.0f * Time.deltaTime;
        }
        else
        {
            ClearEffect();
            rot_Y = 360.0f;
        }
        clear_Logo.rectTransform.localScale = new Vector2(logo_scale, logo_scale);
        clear_Logo.rectTransform.eulerAngles = new Vector3(0.0f, rot_Y, 0.0f);
    }

    void GameClear2()
    {
        if (pos_Y <= 120)
        {
            pos_Y += 250.0f * Time.deltaTime;
        }
        else
        {
            if(menu_rot_x <= 0.0f)
            {
                menu_rot_x += 270.0f * Time.deltaTime;
            }
            else
            {
                alpha += 2.0f * Time.deltaTime;
                next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
                select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
                retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
                if (alpha >= 1.0f && alpha <= 1.05f)
                {
                    List1.Select();
                    clear_check = false;
                    Time.timeScale = 0.0f;
                }
            }
        }
        clear_Logo.rectTransform.localPosition = new Vector3(0.0f, pos_Y, 0.0f);
        clear_menu.rectTransform.eulerAngles = new Vector3(menu_rot_x, 0.0f, 0.0f);
    }

    void ClearEffect()
    {
        if (effect_scale <= 0.1f)
        {
            audio.Play();
        }
        if(effect_scale >= 1.5f)
        {
            effect_alpha -= 3.0f * Time.deltaTime;
        }
        if(effect_scale >= 13.0f)
        {
            GameClear2();
        }
        effect_scale += 10.0f * Time.deltaTime;

        clear_Effect.color = new Color(1.0f, 1.0f, 1.0f, effect_alpha);
        clear_Effect.GetComponent<RectTransform>().localScale = new Vector3(effect_scale, effect_scale);
    }
}
