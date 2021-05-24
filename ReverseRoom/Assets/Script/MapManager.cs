using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [Header("ブロックプレハブを入れる")]
    [SerializeField] GameObject[] block_Pre;

    [Header("プレイヤーを入れる")]
    [SerializeField] GameObject player;

    [Header("プレイヤーの生成位置を指定")]
    [SerializeField] float player_pos_x;
    [SerializeField] float player_pos_y;

    [Header("鍵を入れる")]
    [SerializeField] GameObject key;

    [Header("鍵の生成位置を指定")]
    [SerializeField] float key_pos_x;
    [SerializeField] float key_pos_y;

    [Header("扉を入れる")]
    [SerializeField] GameObject door;

    [Header("扉の生成位置を指定")]
    [SerializeField] float door_pos_x;
    [SerializeField] float door_pos_y;

    string now_scene;

    // Start is called before the first frame update
    void Start()
    {
        now_scene = SceneManager.GetActiveScene().name;

        for(int i = 0; i < block_Pre.Length; i++)
        {
            Instantiate(block_Pre[i]);
        }

        Instantiate(player, new Vector3(player_pos_x, player_pos_y, 0.0f), Quaternion.identity);

        if (now_scene == "TitleScene")
        {

        }
        else
        {
            Instantiate(key, new Vector3(key_pos_x, key_pos_y, 0.0f), Quaternion.identity);
            Instantiate(door, new Vector3(door_pos_x, door_pos_y, 0.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
