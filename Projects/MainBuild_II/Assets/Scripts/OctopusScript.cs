using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusScript : MonoBehaviour
{
    private Vector3 position;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        position = this.GetComponent<Transform>().position;
        position.x += speed;
        this.GetComponent<Transform>().position = position;
    }
}
