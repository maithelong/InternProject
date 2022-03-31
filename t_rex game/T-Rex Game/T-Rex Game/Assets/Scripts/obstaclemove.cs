using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclemove : MonoBehaviour
{
    [SerializeField] public float movespeed;
    Gamecontroller m_gc;
    [SerializeField] GameObject catuss;
    //UImanager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<Gamecontroller>();
       // m_ui = FindObjectOfType<UImanager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * movespeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Border"))
        {
            //m_gc = col.GetComponent<Gamecontroller>();
            m_gc.ScoreIncrement();
           // m_ui.setScoretext("score :" + );
            Debug.Log("nguoi choi da nhan duoc 1 dime");
            Destroy(gameObject);
        }
    }
}
