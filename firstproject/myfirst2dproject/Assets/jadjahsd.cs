using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jadjahsd : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Vector2 vt;
    [SerializeField] private float speedy = 20f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        vt = new Vector2(x, y).normalized;
        
    }
    private void FixedUpdate()
    {
        rig.velocity = new Vector2(vt.x, vt.y) * speedy;

    }
}
