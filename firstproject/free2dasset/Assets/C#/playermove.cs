using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
   [SerializeField] public float movespeed = 0;
    [SerializeField] public float xd ;
    [SerializeField] public float yd;
    Rigidbody2D rb;
    public float jmpforce;
    bool isontheground=true;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if(jump&&isontheground)
        {
            rb.AddForce(Vector2.up * jmpforce);
           isontheground = false;
            animator.SetBool("isjumping", true);
        }
        animator.SetBool("isjumping", false);
        xd = Input.GetAxisRaw("Horizontal");

        float movestepp = xd * movespeed * Time.deltaTime;
        if(!Mathf.Approximately(movestepp,0))
        {
            transform.rotation = movestepp < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }    
       transform.position += new Vector3(movestepp, 0, 0);
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            isontheground = true;
        }

    }
}
