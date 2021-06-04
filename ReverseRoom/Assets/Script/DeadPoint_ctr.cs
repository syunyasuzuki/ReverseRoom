using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint_ctr : MonoBehaviour
{
    [HideInInspector] public bool player_dead;

    // Start is called before the first frame update
    void Start()
    {
        player_dead = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            player_dead = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Block")
        {
            player_dead = false;
        }
    }
}
