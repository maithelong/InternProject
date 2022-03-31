using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float velocity = 1;
    Rigidbody2D rb;
    gamemng gamemanager;
    public AudioSource aus;
    public AudioClip point;
    public AudioClip crash;
    public AudioClip gameover;
    public AudioClip fly;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gamemanager = FindObjectOfType<gamemng>();
       // aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
            if(aus&&fly)
            {
                aus.PlayOneShot(fly);
            }    
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("point"))
        {
            if (aus && crash)
            {
                aus.PlayOneShot(point);
            }
        } else if (collision.gameObject.CompareTag("pipe"))
       { if (aus && crash)
            { aus.PlayOneShot(crash);
                //aus.PlayOneShot(gameover); 
                //Debug.Log(aus.isPlaying);

            } }  
        gamemanager.GameOver();
    }
}
