using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLining : MonoBehaviour
{
    private float speedFire = 7f;
    private Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 6f);
        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = transform.right * speedFire;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
}
