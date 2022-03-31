using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
   public  GameObject bullet;
    public Transform shootingpoint;
    public float moveSpeed;
    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        if(transform.position.x<-10&&xDir<0|| transform.position.x > 9.3 && xDir > 0)
        { return; }    
        transform.position += Vector3.right * moveSpeed * xDir * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        { shoot(); }    
    }
    private void shoot()
    {
        if(bullet&&shootingpoint)
        Instantiate(bullet, shootingpoint.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {

            gc.setIsGameOverState(true);
            Debug.Log("va cham voi enemy : player");
        }
    }
}
