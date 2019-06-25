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
            Freeze,
            Explicate,
            Recall,
            BanHammer
        }

        public float timer { get; set; }
        public float CDTime { get; set; }
        public KeyCode button { get; set; }

        private static Dictionary<specificType, Type> ablities = new Dictionary<specificType, Type>()
        {
            {specificType.Dash, typeof(DashAbility) },
            {specificType.Freeze, typeof(FreezeAbility) },
            {specificType.Recall, typeof(RecallAbility) }
        };

        public KeyCode key;
        public float CDTimer;
        public float totalCD;

        // Start is called before the first frame update
        void Start()
        {
            CDTime = -1f;
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