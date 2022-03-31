using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareoperate : MonoBehaviour
{
   [SerializeField] public float movespeed = 11f;
    [SerializeField] float xdrirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xdrirection = Input.GetAxisRaw("Horizontal");
       float movestep = movespeed * xdrirection * Time.deltaTime;
       // if ((transform.position.x <= -8.3 &&xdrirection < 0)|| (transform.position.x <= -8.3 && xdrirection > 0))
           // return ;
        transform.position += new Vector3(movestep, 0, 0);
    }
    }
   