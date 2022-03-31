using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int zombieHeath = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void getHit(int damage)
    {
        zombieHeath-=damage;
        if(zombieHeath <= 0)
        {
            dead();
        }    
    }    
    public void dead()
    {
        Destroy(gameObject);

    }    
    void Update()
    {
        
    }
}
