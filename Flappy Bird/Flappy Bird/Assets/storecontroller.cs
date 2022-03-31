using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    void loadscene()
    {
        if (Input.GetMouseButtonDown(0))
        { SceneManager.LoadScene("Changecharacter"); };
    }    
}
