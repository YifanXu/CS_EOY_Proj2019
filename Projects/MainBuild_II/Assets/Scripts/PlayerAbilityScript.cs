using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Internals;

namespace Assets.Scripts
{
    public class PlayerAbilityScript : MonoBehaviour
    {
        public Ability.specificType[] type;
        public Ability[] abilities;
        private bool iconsCallibrated = false;

        // Start is called before the first frame update
        void Start()
        {
            abilities = new Ability[4];
            
            for (int i = 0; i < type.Length; i++)
            {
                if (type[i] != Ability.specificType.None)
                {
                    abilities[i] = Ability.AddAbility(type[i], gameObject);
                    abilities[i].CDTimer = -1f;
                }
            }

            if (abilities[0] != null) abilities[0].key = KeyBinding.GetKey(Control.Ability1);
            if (abilities[1] != null) abilities[1].key = KeyBinding.GetKey(Control.Ability2);
            if (abilities[2] != null) abilities[2].key = KeyBinding.GetKey(Control.Ability3);
            if (abilities[3] != null) abilities[3].key = KeyBinding.GetKey(Control.Ability4);
        }

        // Update is called once per frame
        void Update()
        {
            float[] CDPercentages = new float[4];
            if(!iconsCallibrated && UIScript.staticObject != null) UIScript.CallibrateIcons(type);
            for (int i = 0; i < abilities.Length; i++)
            {
                if (abilities[i] == null)
                {
                    CDPercentages[i] = -1;
                    continue;
                }
                CDPercentages[i] = abilities[i].CDTimer / abilities[i].totalCD;
                if (abilities[i].CDTimer < 0f && Input.GetKeyDown(abilities[i].key))
                {
                    abilities[i].Activate();
                    abilities[i].CDTimer = abilities[i].totalCD;
                }
                if (abilities[i].CDTimer > 0f)
                {
                    abilities[i].CDTimer -= Time.deltaTime;
                }
                
            }

            UIScript.CallibrateCD(CDPercentages);
        }
    }
}