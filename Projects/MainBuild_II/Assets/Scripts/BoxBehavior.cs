﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    public float speed;
    public float rayDistance;
    private bool movingRight = true;
    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);
        if (!groundInfo.collider)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0.0f, -180.0f, 0.0f);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                movingRight = true;
            }
        }
    }
}
