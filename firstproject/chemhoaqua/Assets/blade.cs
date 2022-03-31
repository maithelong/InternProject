using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{ bool iscutting = false;
    Rigidbody2D rg;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startcutting();
        }
        if (Input.GetMouseButtonUp(0))
        {
            stopcutting();
        }
        if (iscutting)
        {
            updatecut();
        }

    }
    void updatecut()
    {
        rg.position = cam.ScreenToWorldPoint(Input.mousePosition);  
    }
    void startcutting()
    {
        iscutting = true;
    }
    void stopcutting()
    {
        iscutting = false;
    }
}
