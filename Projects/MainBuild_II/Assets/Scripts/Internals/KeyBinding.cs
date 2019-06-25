using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Internals
{
    public static class KeyBinding
    {
        public static Dictionary<Control, KeyCode> keySet;

        public static KeyCode GetKey(Control c)
        {
            if (keySet == null) Populate();

            if(keySet.TryGetValue(c, out var k))
            {
                return k;
            }

            throw new ArgumentException($"Control {c} is not supported");
        }

        public static void Populate()
        {
            keySet = new Dictionary<Control, KeyCode>()
            {
                {Control.MoveLeft, KeyCode.LeftArrow },
                {Control.MoveRight, KeyCode.RightArrow },
                {Control.Jump, KeyCode.UpArrow },
                {Control.Ability1, KeyCode. Alpha1},
                {Control.Ability2, KeyCode. Alpha2},
                {Control.Ability3, KeyCode. Alpha3},
                {Control.Ability4, KeyCode. Alpha4},
            };
            Dictionary<Control, KeyCode> newDict = new Dictionary<Control, KeyCode>();
            foreach(var pair in keySet)
            {
                KeyCode newKey = (KeyCode)PlayerPrefs.GetInt("Key" + pair.Key.ToString(), (int)pair.Value);
                newDict.Add(pair.Key, newKey);
            }
            keySet = newDict;
        }
    }
}
