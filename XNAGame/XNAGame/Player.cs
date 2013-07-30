using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAGame
{


    class Player
    {

        public float money; //z.B. Euro als Maßstab

        public int staerke;
        public int wiederstand;
        public int geschicklichkeit;
        public int intelligenz;

        public int gangsterLevel;
        public int gangsterPunkte;

        
        Player()
        {
            money = 10.00f;

            staerke = 10;
            wiederstand = 10;
            geschicklichkeit = 10; 
            intelligenz = 10;
            
            gangsterLevel = 1;
            gangsterPunkte = 0;
        }
    }
}
