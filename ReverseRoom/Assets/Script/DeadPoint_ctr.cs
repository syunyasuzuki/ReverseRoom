using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint_ctr : MonoBehaviour
{
    Camera cam;

    AudioSource audio;
    [SerializeField] AudioClip dead_se;

    bool no_death;
    [HideInInspector] public bool player_dead;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        audio = GetComponent<AudioSource>();
        audio.clip = dead_se;
        player_dead = false;
        no_death = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_ctr.game_over == true)
        {
            if (no_death == true)
            {
                audio.Play();
            }
            no_death = false;
        }
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
