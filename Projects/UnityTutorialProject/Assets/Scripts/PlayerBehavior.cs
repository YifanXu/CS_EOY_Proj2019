using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float spd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = new Vector2();
        if(Input.GetKey(KeyBinding.GetKey(KeyBinding.Control.MoveLeft)))
        {
            delta.x -= spd * Time.deltaTime;
        }
        if (Input.GetKey(KeyBinding.GetKey(KeyBinding.Control.MoveRight)))
        {
            delta.x += spd * Time.deltaTime;
        }
        this.GetComponent<Transform>().position += delta;
    }
}
