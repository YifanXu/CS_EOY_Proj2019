using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectScript : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearText()
    {
        text.text = "";
    }

    public int GetValue()
    {
        return GetComponent<Dropdown>().value;
    }
}
