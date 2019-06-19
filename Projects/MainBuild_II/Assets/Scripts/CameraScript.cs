using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject focus;
    public GameObject background;
    public float LerpFactor = 0.7f;
    public float backgroundFactor = 0.05f;

    private float zConstant;
    private Transform transf;

    // Start is called before the first frame update
    void Start()
    {
        transf = this.GetComponent<Transform>();
        zConstant = transf.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Lerp
        Vector3 newPos = transf.position;
        newPos = Vector3.Lerp(newPos, focus.GetComponent<Transform>().position, LerpFactor);

        //Set Background
        Vector3 delta = transf.position - newPos;
        delta.z = 0;
        background.transform.position += delta * backgroundFactor;

        //Set Camera
        newPos.z = zConstant;
        transf.position = newPos;
    }
}
