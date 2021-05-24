using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 継承用スクリプト
public class Button_ctr : MonoBehaviour
{
    // シーン遷移にかける時間
    [HideInInspector] public float load_Time = 0.5f;

    [HideInInspector] public string now_scene;

    // Start is called before the first frame update
    void Start()
    {
        now_scene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Go_Title()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadTitle), load_Time);
    }
    void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Go_Select()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadSelect), load_Time);
    }
    void LoadSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }

    // ---------------ステージ移動のメソッド---------------------
    public void Stage1()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Player_ctr.key_get = false;
        Invoke(nameof(LoadStage1), load_Time);
    }
    void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Player_ctr.key_get = false;
        Invoke(nameof(LoadStage2), load_Time);
    }
    void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage3), load_Time);
    }
    void LoadStage3()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage4()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage4), load_Time);
    }
    void LoadStage4()
    {
        SceneManager.LoadScene("Stage2");
    }
    // --------------------------------------------------------
}
