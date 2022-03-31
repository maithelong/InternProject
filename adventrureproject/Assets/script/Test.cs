using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    float move, speed=10;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(move * speed, rigidbody.velocity.y);
    }
}
