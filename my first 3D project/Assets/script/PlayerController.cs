using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int damage = 1;
    private float fireTime = 0.2f;
    private float lastFireTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateFireTime();
    }

    private void UpdateFireTime()
    {
        lastFireTime=Time.time;
    }    
    void Fire()
    {
        if (Time.time >= lastFireTime + fireTime)

        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag.Equals("zombie"))
                {
                    hit.transform.gameObject.GetComponent<ZombieController>().getHit(damage);
                }

            }
            UpdateFireTime();
        }
    }    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
            {
            Fire();
        }
        
    }
}
