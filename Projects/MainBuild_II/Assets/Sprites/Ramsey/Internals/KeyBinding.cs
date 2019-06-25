﻿using System;
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
                    {Control.Jump, KeyCode.UpArrow },
                    {Control.Ability1, KeyCode. Alpha1},
                    {Control.Ability2, KeyCode. Alpha2},
                    {Control.Ability3, KeyCode. Alpha3},
                    {Control.Ability4, KeyCode. Alpha4},
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