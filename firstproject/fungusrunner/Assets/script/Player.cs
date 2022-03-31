using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpforce;
    Rigidbody2D rb;
    bool isontheground;
    Gamecontroller m_gc;
    public AudioSource aus;
    public AudioClip jump;
    public AudioClip crash;
    public AudioClip gameover;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        m_gc = FindObjectOfType<Gamecontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isjump = Input.GetKeyDown(KeyCode.Space);
        if (isjump&&isontheground)
        {
            rb.AddForce(Vector2.up * jumpforce);
            isontheground = false;
            if(aus&&jump)
            {
                aus.PlayOneShot(jump);
            }    
        }    
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ground"))
        {
            isontheground = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("barrier"))
        {
            if (aus && crash&&!m_gc.Isgameover())
            {
                aus.PlayOneShot(crash);
            }
            if (aus && gameover)
            {
                aus.PlayOneShot(gameover);
            }
            m_gc.setIsgameoverState(true);
            
            Debug.Log("ban da va phai chuong ngai vat, game over");

        }
    }
}
