using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addscore : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Scoreadd.score++;
    }

}
