using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpInstantiate : MonoBehaviour
{
    public GameObject shrimp;
    public GameObject cannon;
    private int shrimpCount;
    private Transform cannonTransform;
    float timer = 0.0f;
    public float btwShots;
    public float btwRounds;

    // Start is called before the first frame update
    void Start()
    {
        shrimpCount = 0;
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
