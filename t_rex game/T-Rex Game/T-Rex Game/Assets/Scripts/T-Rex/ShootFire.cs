using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform positionFire;
    // Start is called before the first frame update
    void Start()
    {
        
       // bullet = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
        Shoot();
        }
        
    }
    public void Shoot()
    {
        Instantiate(bullet, positionFire.position, positionFire.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("destroyball"))
        {
            Destroy(gameObject);
        }
    }
   

}
