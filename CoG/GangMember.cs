using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    class GangMember:MonoBehaviour
    {
        public string playerName = "player";
        public int strenght = 10;
        public int intelligence = 10;
        public int dexterity = 10;
        public int resistance = 10;

        public Item rangedWeapon = null;
        public Item meleeWeapon = null;
    }
