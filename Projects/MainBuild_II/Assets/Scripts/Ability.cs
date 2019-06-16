using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public abstract class Ability : MonoBehaviour
    {
        public enum specificType
        {
            None,
            Dash,
        }

        private static Dictionary<specificType, Type> ablities = new Dictionary<specificType, Type>()
        {
            {specificType.Dash, typeof(DashAbility) }
        };

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public abstract void Activate();

        public static Ability AddAbility(specificType type, GameObject obj)
        {
            return (Ability)obj.AddComponent(ablities[type]);
        }
    }
}