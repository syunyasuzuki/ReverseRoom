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

    Camera cam;

    float alpha;

    bool stop_check;
    bool playback_check;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        stop_check = false;
        playback_check = false;

        alpha = 0.0f;
        stop_UI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        playback_UI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && cam.orthographicSize == 5.0f)
        {
            alpha = 0.6f;
            stop_check = true;
        }
        if(stop_check == true)
        {
            Stop_UI();
        }

        if (Input.GetKeyDown(KeyCode.X) && cam.orthographicSize == 8.0f)
        {
            alpha = 0.6f;
            playback_check = true;
        }
        if(playback_check == true)
        {
            Playback_UI();
        }
    }

    void Stop_UI()
    {
        alpha -= 1.0f * Time.deltaTime;
        if(alpha <= 0.0f)
        {
            stop_check = false;
        }
        stop_UI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    void Playback_UI()
    {
        alpha -= 1.0f * Time.deltaTime;
        if (alpha <= 0.0f)
        {
            playback_check = false;
        }
        playback_UI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
