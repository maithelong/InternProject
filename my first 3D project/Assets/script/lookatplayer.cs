using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatplayer : MonoBehaviour
{
    public float moveSpeed;
   public GameObject player;
 public   GameObject lookAtTarget;
    public float minMoveSpeed = 0.05f;
    public float maxMoveSpeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtTarget = GameObject.FindGameObjectWithTag("looktarget");
        UpdateMoveSpeed();
    }
    private void UpdateMoveSpeed()
    {
       moveSpeed= Random.Range(minMoveSpeed, maxMoveSpeed);
    }    
    private void Move()
    {
        if (player == null || lookAtTarget == null)
            return;
        transform.LookAt(lookAtTarget.transform.position);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed*Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
