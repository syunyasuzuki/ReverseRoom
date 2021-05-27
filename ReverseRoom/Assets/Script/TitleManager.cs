using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : Button_ctr
{
    [Header("メニューUIを入れる")]
    [SerializeField] GameObject m_MenuPanel;
    [SerializeField] Image m_Menu;
    [SerializeField] Image m_Credit;
    [SerializeField] Image m_Exit;
    [SerializeField] Image m_Back;
    [SerializeField] Button m_List1;
    [SerializeField] Button m_List2;
    [SerializeField] Button m_List3;

    [Header("TitleLogoを入れる")]
    [SerializeField] GameObject title;

    float title_pos_y;
    float alpha;

    float rot_Z;
    float menu_alpha;
    float button_alpha;

    bool menu_open;

    float invokeTime = 1.2f;
    float load_time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0.0f;
        title_pos_y = 0.0f;

        rot_Z = 45.0f;

        menu_alpha = 0.0f;
        button_alpha = 0.0f;

        menu_open = false;

        m_MenuPanel.SetActive(false);

        m_Menu.rectTransform.eulerAngles = new Vector3(0.0f, 0.0f, rot_Z);
        m_Menu.color = new Color(1.0f, 1.0f, 1.0f, menu_alpha);
        m_Credit.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
        m_Exit.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
        m_Back.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);

        title.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        title.transform.position = new Vector3(0.0f, title_pos_y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        TitleLogo();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu_open = true;
        }

        if (menu_open == true)
        {
            OpenMenu();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Invoke(nameof(FadeStart), invokeTime);
        }
    }

    void FadeStart()
    {
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(LoadSelect), load_time);
    }
    void LoadSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }

    void TitleLogo()
    {
        if(Fade_ctr.fade == false)
        {
            alpha += 0.7f * Time.deltaTime;
            if(title_pos_y <= 1.0f)
            {
                title_pos_y += 0.7f * Time.deltaTime;
            }
        }

        title.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        title.transform.position = new Vector3(0.0f, title_pos_y, 0.0f);
    }
    void OpenMenu()
    {
        m_MenuPanel.SetActive(true);
        menu_alpha += 3.0f * Time.deltaTime;
        if (menu_alpha >= 1.0f)
        {
            rot_Z -= 180.0f * Time.deltaTime;
            if (rot_Z <= 0.0f)
            {
                rot_Z = 0.0f;
                button_alpha += 3.0f * Time.deltaTime;
                if (button_alpha >= 1.0f)
                {
                    m_List1.Select();
                    menu_open = false;
                    Time.timeScale = 0.0f;
                }
            }
        }

        m_Menu.rectTransform.eulerAngles = new Vector3(0.0f, 0.0f, rot_Z);
        m_Menu.color = new Color(1.0f, 1.0f, 1.0f, menu_alpha);
        m_Credit.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
        m_Exit.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
        m_Back.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
    }

    public void Back()
    {
        m_MenuPanel.SetActive(false);
        Time.timeScale = 1.0f;

        rot_Z = 45.0f;

        menu_alpha = 0.0f;
        button_alpha = 0.0f;

        m_Menu.rectTransform.eulerAngles = new Vector3(0.0f, 0.0f, rot_Z);
        m_Menu.color = new Color(1.0f, 1.0f, 1.0f, menu_alpha);
        m_Credit.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
        m_Exit.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
        m_Back.color = new Color(1.0f, 1.0f, 1.0f, button_alpha);
    }

    public void EndApplication()
    {
        Fade_ctr.fade = true;
        Fade_ctr.fade_out = true;
        Invoke(nameof(EndApplication2), load_time);
        Time.timeScale = 1.0f;
    }
    void EndApplication2()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        //アプリを終了させる
        UnityEngine.Application.Quit();
    }
}
