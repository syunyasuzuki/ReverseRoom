using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_ctr : MonoBehaviour
{
    [Header("Order in Layerの数を指定(1 or -1)")]
    [SerializeField] int layer_number;

    GameObject parent;

    float white;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("ReverseObject");
        transform.parent = parent.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (layer_number == 1)
        {
            white = 1.0f;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        if(layer_number == -1)
        {
            white = 0.5f;
            GetComponent<BoxCollider2D>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer_number;
    }
}
