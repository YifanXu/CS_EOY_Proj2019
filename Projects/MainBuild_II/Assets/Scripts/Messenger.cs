using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    //I am The Messager, and I will deliever the messages, rain or shine.
    //You shall have no other *MESSENGERS* but me.

    public static class Messenger
    {
        public static Ability.specificType[] abilties = new Ability.specificType[4];
        public static bool levelFailed = false;
        public static int levelID = 0;
        public static int SceneBeforeOptions = 0;
    }
}