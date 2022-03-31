using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gnotate : MonoBehaviour
{
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookAtCursor();
    }
    private void lookAtCursor() 
    {
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }    
        transform.LookAt(target);
    }    
}
