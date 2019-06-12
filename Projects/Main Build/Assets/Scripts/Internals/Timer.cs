using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public static float TotalTime;

    // Start is called before the first frame update
    void Start()
    {
        TotalTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;
    }
}
