using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Stop_UIを入れる")]
    [SerializeField] Image stop_UI;
    [Header("Playback_UIを入れる")]
    [SerializeField] Image playback_UI;

    Image modeImage_UI;
    Camera cam;

    enum StateMode
    {
        Play,
        Stop
    }

    StateMode state = StateMode.Play;

    float alpha;

    bool moveNow = false;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0.0f;
        stop_UI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        playback_UI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Test(StateMode.Stop);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Test(StateMode.Play);
        }

        if (moveNow)
        {
            Display_UI();
        }
    }

    void Test(StateMode mode)
    {
        if(moveNow || state == mode)
        {
            return;
        }
        
        switch (mode)
        {
            case StateMode.Play:
                modeImage_UI = playback_UI;               
                break;
            case StateMode.Stop:
                modeImage_UI = stop_UI;
                break;
            default:
                return;
        }
        alpha = 0.6f;
        state = mode;
        moveNow = true;
    }

    void Display_UI()
    {
        
        alpha -= 1.0f * Time.deltaTime;
        if (alpha <= 0.0f)
        {
            moveNow = false;
        }
        modeImage_UI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
