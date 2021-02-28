using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("ブロックプレハブを入れる")]
    [SerializeField] GameObject[] block_Pre;

    [Header("プレイヤーを入れる")]
    [SerializeField] GameObject player;

    [Header("鍵を入れる")]
    [SerializeField] GameObject key;

    [Header("鍵の初期位置を指定")]
    [SerializeField] float key_pos_x;
    [SerializeField] float key_pos_y;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < block_Pre.Length; i++)
        {
            Instantiate(block_Pre[i]);
        }

        Instantiate(player);
        Instantiate(key, new Vector3(key_pos_x, key_pos_y, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
