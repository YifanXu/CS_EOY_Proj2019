using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class KeyBinding
{
    public enum Control
    {
        MoveLeft,
        MoveRight,
        Jump
    }

    private static Dictionary<Control, KeyCode> keybind = new Dictionary<Control, KeyCode>()
    {
        {Control.MoveLeft, KeyCode.A },
        {Control.MoveRight, KeyCode.D },
        {Control.Jump, KeyCode.W },
    };

    public static void Initialize()
    {
        
    }

    public static KeyCode GetKey(Control c)
    {
        return keybind[c];
    }
}
