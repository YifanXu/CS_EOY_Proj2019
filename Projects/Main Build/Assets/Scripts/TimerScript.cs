using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript staticObject;

    public float MaxTime;
    public GameObject ClockHand;
    public GameObject TimeText;
    public GameObject[] TimeTicks;

    private Transform handTransf;
    private Text timeTextComp;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        staticObject = this;

        if (TimeTicks.Length != 4) throw new System.Exception("There must be 4 timeticks!");
        handTransf = ClockHand.GetComponent<Transform>();
        timeTextComp = TimeText.GetComponent<Text>();

        time = MaxTime;
        timeTextComp.text = $"{time} / {MaxTime}";
        handTransf.eulerAngles = new Vector3(0, 0, 0);
        for(int i = 0; i < 4; i++)
        {
            TimeTicks[i].GetComponent<Text>().text = (MaxTime / 4f * i).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0) time -= Time.deltaTime;
        else time = 0;

        string roundedTime = (Mathf.Round(time * 100f) / 100f).ToString();
        int decimalPoint = roundedTime.IndexOf('.');
        if (decimalPoint == -1) roundedTime += ".00";
        else if (decimalPoint == roundedTime.Length - 2) roundedTime += "0";
        timeTextComp.text = $"{ roundedTime } / {MaxTime}";
        handTransf.eulerAngles = new Vector3(0, 0, 360 - time / MaxTime * 360f);
    }

    public static void ChangeTime(float delta)
    {
        staticObject.time += delta;
    }
}
