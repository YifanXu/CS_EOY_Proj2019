using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class LevelSelectScript : MonoBehaviour
    {
        public class LevelMetaData
        {
            public string title; //Title of Level
            public string description; //Short description
            public int timeLimit; //Time given to player
            public int abilityLimit; //How many abilities are allowed to be carried into the level;

            public LevelMetaData(string title, string description, int timeLimit, int abilityLimit)
            {
                this.title = title;
                this.description = description;
                this.timeLimit = timeLimit;
                this.abilityLimit = abilityLimit;
            }
        }

        //How many scenes in build sequence before the first level
        public int SceneNumOffSet = 2;
        public Button[] buttons;
        public string[] levelTitles;
        public Dropdown[] abilitySelections;
        public TextMeshProUGUI[] keyText;
        public GameObject prepPanel;
        public TextMeshProUGUI LevelTitle;

        private int SelectedLevel = 0;

        // Start is called before the first frame update
        void Start()
        {
            keyText[0].text = Internals.KeyBinding.GetKey(Internals.Control.Ability1).ToString();
            keyText[1].text = Internals.KeyBinding.GetKey(Internals.Control.Ability2).ToString();
            keyText[2].text = Internals.KeyBinding.GetKey(Internals.Control.Ability3).ToString();
            keyText[3].text = Internals.KeyBinding.GetKey(Internals.Control.Ability4).ToString();

            //Set buttons
            CallibrateButtons();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SelectLevel(int id)
        {
            SelectedLevel = id + SceneNumOffSet - 1;
            Messenger.levelID = id;
            prepPanel.SetActive(true);
            LevelTitle.text = $"Level {id}: {levelTitles[id - 1]}";
        }

        public void ConfirmLevel()
        {
            for(int i = 0; i < 4; i++)
            {
                Messenger.abilties[i] = (Ability.specificType)abilitySelections[i].value;
            }
            SceneManager.LoadScene(SelectedLevel);
        }

        public void CancelPrep()
        {
            prepPanel.SetActive(false);
        }

        public void BackToMenu()
        {
            Debug.Log("Back 2 menu");
            SceneManager.LoadScene(0);
        }

        public void ChangeAbility (int dropDownId)
        {
            abilitySelections[dropDownId].gameObject.GetComponent<AbilitySelectScript>().ClearText();
            int value = abilitySelections[dropDownId].value;
            if (value == 0) return;

            for (int i = 0; i < 4; i++)
            {
                if(i != dropDownId && abilitySelections[i].value == value)
                {
                    abilitySelections[i].value = 0;
                    abilitySelections[i].gameObject.GetComponent<AbilitySelectScript>().ClearText();
                }
            }
        }

        private void CallibrateButtons ()
        {
            int levelCap = PlayerPrefs.GetInt("level", 1);
            Debug.Log($"Max Level = {levelCap}");
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = i < levelCap;
            }
        }
    }
}