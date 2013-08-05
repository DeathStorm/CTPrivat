using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    class Player:GangMember
    {
        
        public string gangName = "gangname";
        public int gangsterLevel = 1;
        public int gansterPoints = 0;
        public int movementPoints = 10;


        public Item body = null;
        public Item head = null;
        public Item legs = null;
        public Item shoes = null;
        public Item smartPhone = null;
        public Item[] inventory = new Item[6]; 

    }
