using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("ブロックプレハブを入れる")]
    [SerializeField] GameObject[] block_Pre;

    [Header("プレイヤーを入れる")]
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < block_Pre.Length; i++)
        {
            Instantiate(block_Pre[i]);
        }

        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
