using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Sprite[] valueSprites;
    public GameObject valueText;
    public int value = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (valueSprites == null || valueSprites.Length != 9)
        {
            throw new System.Exception("There should be 9 sprites in the valueSprites array");
        }
        if (value < 1 || value > 9) throw new System.ArgumentException("value of coin must be between 1 and 9 (inclusive))");
        valueText.GetComponent<SpriteRenderer>().sprite = valueSprites[value - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            TimerScript.ChangeTime((float)value);
            Destroy(this.gameObject);
        }
    }
}
