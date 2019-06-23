using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Internals;

namespace Assets.Scripts
{
    public class PlayerAbilityScript : MonoBehaviour
    {
        public Ability.specificType[] type;
        private Ability[] abilities;
        private bool iconsCallibrated = false;

        // Start is called before the first frame update
        void Start()
        {
            abilities = new Ability[4];
            for (int i = 0; i < type.Length; i++)
            {
                if(type[i] != Ability.specificType.None)
                abilities[i] = Ability.AddAbility(type[i], gameObject);
            }
            if(abilities[0] != null) abilities[0].button = KeyBinding.GetKey(Control.Ability1);
            if(abilities[1] != null) abilities[1].button = KeyBinding.GetKey(Control.Ability2);
            if(abilities[2] != null) abilities[2].button = KeyBinding.GetKey(Control.Ability3);
            if(abilities[3] != null) abilities[3].button = KeyBinding.GetKey(Control.Ability4);
        }

        // Update is called once per frame
        void Update()
        {
            if(!iconsCallibrated && UIScript.staticObject != null) UIScript.CallibrateIcons(type);
            for (int i = 0; i < abilities.Length; i++)
            {
                if(abilities[i] != null && Input.GetKeyDown(abilities[i].button))
                {
                    abilities[i].Activate();
                }
            }
        }
    }
}