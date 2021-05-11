using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_ctr : MonoBehaviour
{


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
        SceneManager.LoadScene("TitleScene");
    }
    public void Go_Select()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}
