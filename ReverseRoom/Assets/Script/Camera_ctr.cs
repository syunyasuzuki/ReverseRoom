using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_ctr : MonoBehaviour
{
    // メインカメラを取得する変数
    Camera cam;

    string now_scene;

    // 標準のカメラサイズ
    float normal_size = 5.0f;
    // 変更後のカメラサイズ
    float change_size = 8.0f;

    // カメラサイズを変更させるときの変数
    bool size_up;
    // カメラサイズをもとに戻すときの変数
    bool size_down;

    // カメラサイズが変更後か標準サイズか判別する変数
    public static bool size_change;

    // Start is called before the first frame update
    void Start()
    {
        // メインカメラを取得
        cam = Camera.main;

        now_scene = SceneManager.GetActiveScene().name;

        //------変数の初期化------
        size_up = false;
        size_down = false;
        size_change = false;
        //-----------------------
    }

    // Update is called once per frame
    void Update()
    {
        if(ClearManager.clear_check == true)
        {
            return;
        }

        if(now_scene == "TitleScene")
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && cam.orthographicSize <= normal_size)
            {
                size_change = true;
                size_up = true;
            }
        }

        if (Reverse_ctr.now_rotato == false)
        {
            if (Input.GetKeyDown(KeyCode.X) && cam.orthographicSize >= change_size)
            {
                size_down = true;
            }
        }

        if (size_up == true)
        {
            SizeUp();
        }

        if(size_down == true)
        {
            SizeDown();
        }
    }

    void SizeUp()
    {
        cam.orthographicSize += 5.0f * Time.deltaTime;
        if (cam.orthographicSize >= change_size)
        {
            cam.orthographicSize = change_size;
            size_up = false;
        }
    }

    void SizeDown()
    {
        cam.orthographicSize -= 5.0f * Time.deltaTime;
        if (cam.orthographicSize <= normal_size)
        {
            cam.orthographicSize = normal_size;
            size_down = false;
            size_change = false;
        }
    }
}
