using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    [SerializeField] private Transform Bird_Fire;
    [SerializeField] private GameObject Bird_;
    [SerializeField] private float startTimeSpawner;
    private float TimeSpawner;
    public int  movespeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(DelayBird());
        CreateBird();
       //transform.position = transform.position + Vector3.left * movespeed * Time.deltaTime;
    }

    void CreateBird()
    {
        if (TimeSpawner <= 0)
        {
            Instantiate(Bird_, Bird_Fire.position, Bird_Fire.rotation);
            TimeSpawner = startTimeSpawner;
        }
        else
        {
            TimeSpawner -= Time.deltaTime;
            
        }
    }
    IEnumerator DelayBird()
    {
        yield return new WaitForSeconds(2f);
        CreateBird();
    }
}
