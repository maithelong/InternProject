using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jump = 20f;
    private Rigidbody2D rigi;
    private Animator Ani;
    private PolygonCollider2D collider2D;
    [SerializeField] LayerMask layer;
    Gamecontroller m_gc;
    bool isontheground;
    public float jumpforce;
    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<PolygonCollider2D>();
        m_gc = FindObjectOfType<Gamecontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isjump = Input.GetKeyDown(KeyCode.Space);
        if (isjump && isontheground)
        {
           rigi.AddForce(Vector2.up * jumpforce);
            isontheground = false;
        }
            //JumpUp();
            //JumpDown();
        }
    private void FixedUpdate()
    {
        
    }
    private void JumpUp()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) /*&& isBool() ==true*/)
        {
            Ani.SetTrigger("Jump");
            //Ani.SetTrigger("Run");
            rigi.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
        else/* if (isBool() == false)*/
        {
            Ani.SetTrigger("Run");
          //  Ani.SetTrigger("Jump");
        }


    }
    private void JumpDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) )
        {
            //rigi.AddForce(Vector2.down * jump * 2, ForceMode2D.Impulse);
            rigi.velocity = Vector2.down * jump * 2;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isontheground = true;
        }
    }
        public bool isBool()
    {
        RaycastHit2D raycat = Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down , 0.1f,layer);
        if (raycat.collider == false)
        {
            //return raycat.collider != null;
            Ani.SetTrigger("Jump");
        }
        else
        {
            Ani.SetTrigger("Run");
        }
        return raycat.collider != null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("obstackle")|| collision.gameObject.CompareTag("bird"))
        {
            m_gc.setIsgameoverState(true);
        }
        else
       {
           m_gc.setIsgameoverState(false);
       } 
            
        
    }
}
