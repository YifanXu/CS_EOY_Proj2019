using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject focus;
    public float LerpFactor = 0.7f;

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
        Vector3 pos = transform.position;
        pos = Vector3.Lerp(pos, focus.GetComponent<Transform>().position, LerpFactor);
        pos.z = zConstant;
        transf.position = pos;
    }
}
