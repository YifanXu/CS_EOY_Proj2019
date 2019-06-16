using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Internals;

namespace Assets.Scripts
{
    public class PlayerAbilityScript : MonoBehaviour
    {
        public Ability.specificType[] type;
        private KeyCode[] abilitiesCode;
        private Ability[] abilities;

        // Start is called before the first frame update
        void Start()
        {
            abilitiesCode = new KeyCode[4];
            abilitiesCode[0] = KeyBinding.GetKey(Control.Ability1);
            abilitiesCode[1] = KeyBinding.GetKey(Control.Ability2);
            abilitiesCode[2] = KeyBinding.GetKey(Control.Ability3);
            abilitiesCode[3] = KeyBinding.GetKey(Control.Ability4);

            abilities = new Ability[4];
            for (int i = 0; i < type.Length; i++)
            {
                if(type[i] != Ability.specificType.None)
                abilities[i] = Ability.AddAbility(type[i], gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for(int i = 0; i < abilitiesCode.Length; i++)
            {
                if(Input.GetKeyDown(abilitiesCode[i]))
                {
                    abilities[i].Activate();
                }
            }
        }
    }
}