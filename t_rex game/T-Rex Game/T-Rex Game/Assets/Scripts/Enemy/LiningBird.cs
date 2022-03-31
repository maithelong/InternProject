using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiningBird : MonoBehaviour
{
    private Rigidbody2D rigi;
   private float speedBird=-12f ;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = transform.right * speedBird ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border") || collision.CompareTag("ball")) ;
        {
            Destroy(gameObject);
        }
    }
    /*  [SerializeField] public float movespeed;
        Gamecontroller m_gc;
        // Start is called before the first frame update
        void Start()
        {
            m_gc = FindObjectOfType<Gamecontroller>();

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = transform.position + Vector3.left * movespeed * Time.deltaTime;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("scenelimit"))
            {
                m_gc.ScoreIncrement();
                Debug.Log("nguoi choi da nhan duoc 1 dime");
                Destroy(gameObject);
            }
        }*/
}
