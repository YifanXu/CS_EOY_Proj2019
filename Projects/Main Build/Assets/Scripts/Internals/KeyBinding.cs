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
            if(keySet == null)
            {
                keySet = new Dictionary<Control, KeyCode>()
                {
                    { Control.MoveLeft, KeyCode.LeftArrow },
                    { Control.MoveRight, KeyCode.RightArrow },
                    {Control.Jump, KeyCode.UpArrow }
                };
            }
            if(keySet.TryGetValue(c, out var k))
            {
                return k;
            }
            throw new ArgumentException($"Control {c} is not supported");
        }
    }
}
