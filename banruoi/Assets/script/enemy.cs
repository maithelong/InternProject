using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float movespeed;
    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * movespeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("deathzone"))
        {
            gc.setIsGameOverState(true);
            Destroy(gameObject);
            Debug.Log("va cham voi deathzone ; enemy");
        }    
    }
}
