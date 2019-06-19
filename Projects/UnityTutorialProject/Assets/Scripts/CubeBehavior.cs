using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public float spd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.GetComponent<Transform>().position;
        position.x += spd;
        this.GetComponent<Transform>().position = position;
    }
}
