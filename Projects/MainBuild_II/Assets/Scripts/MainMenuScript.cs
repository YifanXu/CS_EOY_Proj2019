using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class MainMenuScript : MonoBehaviour
    {
        public GameObject creditPanel;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartButton()
        {
            SceneManager.LoadScene(1);
        }

        public void ResetButton()
        {
            PlayerPrefs.SetInt("level", 1);
        }

        public void KeyBindButton()
        {
            Messenger.SceneBeforeOptions = 0;
            SceneManager.LoadScene(2);
        }

        public void CreditsToggle()
        {
            creditPanel.SetActive(!creditPanel.activeSelf);
        }
        
        public void QuitButton()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}
