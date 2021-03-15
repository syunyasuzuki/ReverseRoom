using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_ctr : MonoBehaviour
{
    Animator anima;

    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();

        parent = GameObject.FindGameObjectWithTag("ReverseObject");

        transform.parent = parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_ctr.key_get == true)
        {
            anima.SetTrigger("OpenTrigger");
        }
    }
}
