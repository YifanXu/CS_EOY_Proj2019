using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpInstantiate : MonoBehaviour
{
    public GameObject shrimp;
    public GameObject cannon;
    private int shrimpCount = 0;
    private Transform cannonTransform;
    private float timer = 0.0f;
    public float btwShots = 0.1f;
    public float btwRounds = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cannonTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (shrimpCount == 0 || shrimpCount % 3 > 0)
        {
            if (timer > btwShots)
            {
                timer = 0.0f;
                shrimp.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                Instantiate(shrimp, cannonTransform);
                shrimpCount++;
            }
        }
        else
        {
            if (timer > btwRounds)
            {
                timer = 0.0f;
                shrimpCount = 0;
            }
        }
    }
}
