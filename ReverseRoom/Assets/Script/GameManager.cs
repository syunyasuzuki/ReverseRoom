using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Button_ctr
{
    //[SerializeField] Image m_StageClear;
    //[SerializeField] Image m_Title;
    //[SerializeField] Image m_Select;
    //[SerializeField] Image m_Back;
    [SerializeField] GameObject m_Menu;
    [SerializeField] Button m_List1;
    [SerializeField] Button m_List2;
    [SerializeField] Button m_List3;

    public static bool game_start;
    public static bool game_clear;

    // Start is called before the first frame update
    void Start()
    {
        game_start = true;
        game_clear = false;

        m_Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(game_clear == true)
        {
            GameClear();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    void OpenMenu()
    {
        m_Menu.SetActive(true);
        m_List1.Select();
        Time.timeScale = 0.0f;
    }

    void GameClear()
    {

    }

    public void Back()
    {
        m_Menu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
