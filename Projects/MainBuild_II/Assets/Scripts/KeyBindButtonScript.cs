using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Internals;
using UnityEngine.UI;
using Assets.Scripts.Internals;
using TMPro;

namespace Assets.Scripts
{
    public class KeyBindButtonScript : MonoBehaviour
    {
        public Control function;
        public TextMeshProUGUI text;

        // Start is called before the first frame update
        void Start()
        {
            text.text = KeyBinding.GetKey(function).ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateText(string newText)
        {
            text.text = newText;
        }
    }
}
