using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackGround : MonoBehaviour
{
    
        float scrollSpeed = -5f;

        Vector2 startPos;
        void Start()
        {
            startPos = transform.position;
        }

        void Update()
        {
            float newPos = Mathf.Repeat(Time.time * scrollSpeed, 43);
            transform.position = startPos + Vector2.right * newPos;
        }



}
