using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloperate : MonoBehaviour
{
    public AudioSource aus;
    public AudioClip vacham;
    public AudioClip gameover;
    gamecontroller m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<gamecontroller>();
        aus = FindObjectOfType<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(aus&&vacham)
            {

                aus.PlayOneShot(vacham);
            }    
            m_gc.incrementscore();
             Destroy(gameObject);
            Debug.Log("bong da cham vao gia do");
           
        }    
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("deathzone"))
        {
            if(aus&&gameover)
            {
                aus.PlayOneShot(gameover);
            }    
            m_gc.setgameover(true);
            Destroy(gameObject);
            Debug.Log("bong da cham vao deathzone");
            
        }    
           
    }
}
