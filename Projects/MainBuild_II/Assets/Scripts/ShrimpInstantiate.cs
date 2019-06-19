using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpInstantiate : MonoBehaviour
{
    public GameObject shrimp;
    public GameObject cannon;
    public Sprite rest;
    public Sprite mid;
    public Sprite shot;

    private Transform cannonTransform;

    private float timer = 0.0f;
    public float load = 0.1f;
    public float shoot = 0.1f;
    private int shrimpCount = 0;
    public float btwShots = 0.1f;
    public float btwRounds = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cannonTransform = cannon.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cannon.GetComponent<SpriteRenderer>().sprite == rest)
        {
            timer += Time.deltaTime;
            if (timer >= load)
            {
                timer = 0.0f;
                cannon.GetComponent<SpriteRenderer>().sprite = mid;
            }
        }
        else if (cannon.GetComponent<SpriteRenderer>().sprite == mid)
        {
            timer += Time.deltaTime;
            if (timer >= shoot)
            {
                timer = 0.0f;
                cannon.GetComponent<SpriteRenderer>().sprite = shot;
            }
        }
        else if (cannon.GetComponent<SpriteRenderer>().sprite == shot)
        {
            timer += Time.deltaTime;
            if (shrimpCount == 0 || shrimpCount % 3 > 0)
            {
                if (timer >= btwShots)
                {
                    timer = 0.0f;
                    shrimp.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    Instantiate(shrimp, cannonTransform);
                    shrimpCount++;
                    cannon.GetComponent<SpriteRenderer>().sprite = rest;
                }
            }
            else
            {
                if (timer >= btwRounds)
                {
                    timer = 0.0f;
                    shrimpCount = 0;
                    cannon.GetComponent<SpriteRenderer>().sprite = rest;
                }
            }
        }
    }
}
