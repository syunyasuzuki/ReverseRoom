using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFrame_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(1 or -1)")]
    [SerializeField] int layer_number;

    float white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (layer_number == 1)
        {
            white = 1.0f;
            GetComponent<EdgeCollider2D>().enabled = true;
        }
        if (layer_number == -1)
        {
            white = 0.5f;
            GetComponent<EdgeCollider2D>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;
    }
}
