using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class UIScript : MonoBehaviour
    {
        public static UIScript staticObject;

        private static Dictionary<Ability.specificType, Sprite> spriteDictionary;

        public float MaxTime;
        public GameObject ClockHand;
        public GameObject TimeText;
        public GameObject[] TimeTicks;

        public GameObject[] abilityObjs;
        public Sprite[] abilitySprites;

        private RectTransform handTransf;
        private Text timeTextComp;

        public bool isFrozen = false;
        private float time;

        // Start is called before the first frame update
        void Start()
        {
            staticObject = this;

            if (TimeTicks.Length != 4) throw new System.Exception("There must be 4 timeticks!");
            handTransf = ClockHand.GetComponent<RectTransform>();
            timeTextComp = TimeText.GetComponent<Text>();

            time = MaxTime;
            timeTextComp.text = $"{time} / {MaxTime}";
            handTransf.eulerAngles = new Vector3(0, 0, 0);
            for (int i = 0; i < 4; i++)
            {
                TimeTicks[i].GetComponent<Text>().text = (MaxTime / 4f * i).ToString();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!isFrozen && time > 0f) time -= Time.deltaTime;
            else if(time < 0f) time = 0f;

            string roundedTime = (Mathf.Round(time * 100f) / 100f).ToString();
            int decimalPoint = roundedTime.IndexOf('.');
            if (decimalPoint == -1) roundedTime += ".00";
            else if (decimalPoint == roundedTime.Length - 2) roundedTime += "0";
            timeTextComp.text = $"{ roundedTime } / {MaxTime}";
            handTransf.eulerAngles = new Vector3(0, 0, 360f - time / MaxTime * 360f);
        }

        public static void ChangeTime(float delta)
        {
            staticObject.time += delta;
            if (staticObject.time > staticObject.MaxTime)
            {
                staticObject.time = staticObject.MaxTime;
            }
        }

        public static void CallibrateIcons(Ability.specificType[] types)
        {
            spriteDictionary = new Dictionary<Ability.specificType, Sprite>()
            {
                {Ability.specificType.Freeze, staticObject.abilitySprites[0] },
                {Ability.specificType.Dash, staticObject.abilitySprites[1] },
                {Ability.specificType.None, staticObject.abilitySprites[4] },
            };
            for (int i = 0; i < types.Length; i++)
            {
                staticObject.abilityObjs[i].GetComponent<Image>().sprite = spriteDictionary[types[i]];
            }
        }
    }
}