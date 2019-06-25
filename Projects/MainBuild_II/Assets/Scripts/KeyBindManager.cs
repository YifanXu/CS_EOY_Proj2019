using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Internals;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class KeyBindManager : MonoBehaviour
    {
        public GameObject currentKey = null;
        public Color KeyPressedColor;

        // Start is called before the first frame update
        void Start()
        {
            KeyBinding.Populate();
            currentKey = null;
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnGUI()
        {
            if (currentKey != null)
            {
                Event e = Event.current;
                if (e.isKey)
                {
                    var function = currentKey.GetComponent<KeyBindButtonScript>().function;
                    Debug.Log($"{function.ToString()} binded to {e.keyCode}");
                    KeyBinding.keySet[function]  = e.keyCode;
                    PlayerPrefs.SetInt("Key" + function.ToString(), (int)e.keyCode);
                    currentKey.GetComponent<Image>().color = Color.white;
                    currentKey.GetComponent<KeyBindButtonScript>().UpdateText(e.keyCode.ToString());
                    currentKey = null;
                }
            }
        }

        public void ChangeKey (GameObject clicked)
        {
            Debug.Log($"changekey {clicked.name}");
            if(currentKey != null)
            {
                currentKey.GetComponent<Image>().color = Color.white;
            }
            currentKey = clicked;
            clicked.GetComponent<Image>().color = KeyPressedColor;
        }

        public void Back2Menu ()
        {
            SceneManager.LoadScene(Messenger.levelID);
        }
    }
}
