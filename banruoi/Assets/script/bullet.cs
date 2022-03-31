using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float DestroyTime;
    Rigidbody2D rb;
    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType<GameController>();
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            gc.ScoreIncreament();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("va cham coi enemy:dan");
        }    
    }
}
