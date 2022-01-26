using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_ctr : MonoBehaviour
{
    float white;

    // Start is called before the first frame update
    void Start()
    {
        white = 0.2f;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(white, white, white, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
