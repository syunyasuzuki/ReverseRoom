using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 継承用スクリプト
public class Button_ctr : MonoBehaviour
{
    // シーン遷移にかける時間
    float load_Time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

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
        SceneManager.LoadScene("Stage3");
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
        SceneManager.LoadScene("Stage4");
    }

    public void Stage5()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage5), load_Time);
    }
    void LoadStage5()
    {
        SceneManager.LoadScene("Stage5");
    }

    public void Stage6()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage6), load_Time);
    }
    void LoadStage6()
    {
        SceneManager.LoadScene("Stage6");
    }

    public void Stage7()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage7), load_Time);
    }
    void LoadStage7()
    {
        SceneManager.LoadScene("Stage7");
    }

    public void Stage8()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage8), load_Time);
    }
    void LoadStage8()
    {
        SceneManager.LoadScene("Stage8");
    }

    public void Stage9()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage9), load_Time);
    }
    void LoadStage9()
    {
        SceneManager.LoadScene("Stage9");
    }

    public void Stage10()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage10), load_Time);
    }
    void LoadStage10()
    {
        SceneManager.LoadScene("Stage10");
    }

    public void Stage11()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage11), load_Time);
    }

    void LoadStage11()
    {
        SceneManager.LoadScene("Stage11");
    }

    public void Stage12()
    {
        Time.timeScale = 1.0f;
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadStage12), load_Time);
    }
    void LoadStage12()
    {
        SceneManager.LoadScene("Stage12");
    }
    // --------------------------------------------------------
}
