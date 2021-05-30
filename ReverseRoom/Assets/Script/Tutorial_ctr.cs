using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_ctr : MonoBehaviour
{
    Camera cam;

    [SerializeField] Image up_arrow;
    [SerializeField] Image down_arrow;
    [SerializeField] Image right_arrow;
    [SerializeField] Image left_arrow;
    [SerializeField] Image space;

    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        alpha = 0.0f;

        up_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        down_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        right_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        left_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        space.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        Tutorial();
    }

    void Tutorial()
    {
        if (cam.orthographicSize >= 8.0f)
        {
            alpha = 0.6f;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            alpha = 0.0f;
        }

        up_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        down_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        right_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        left_arrow.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        space.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
