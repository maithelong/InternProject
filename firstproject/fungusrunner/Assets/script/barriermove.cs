using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriermove : MonoBehaviour
{
   [SerializeField] public float movespeed;
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
    }
}
