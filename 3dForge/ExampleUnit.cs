using System;
using System.Collections.Generic;
using System.Text;

namespace _3dForge
{

    public class ExampleUnit:Unit
    {
        //Monster Maximal Werte
        const float maxHealth = 100.0f;
        const float maxResistance = 10.0f; //Wiederstand, wird von allem körperlichen Standen abgezogen und verbraucht sich nicht.
        const float maxArmor = 100.0f;
        const float maxShield = 100.0f;
        const float maxSpeed = 10.0f; //Wer macht die Einheitenbewegung?

        //Enviroment Werte
        const string name = "Monster";
        const float money = 1.0f;
        const float experience = 10.0f;
        const int killsPlayerLivePoints = 1;

        //Sonderfähigkeiten
        public const bool isFlying = false;

        //Regenerationen
        const float healthRegeneration = 0.0f;
        const float shieldRegeneration = 0.0f;
        const float armorRegeneration = 0.0f;

        //Resistenzen
        const bool isPhysicalResist = false;
        const bool isFireResist = false;
        const bool isIceResist = false;
        const bool isWindResist = false;
        const bool isEarthResist = false;
        const bool isLaserResist = false;

        //Immunitäten
        const bool isPhysicalImmune = false;
        const bool isFireImmune = false;
        const bool isIceImmune = false;
        const bool isWindImmune = false;
        const bool isEarthImmune = false;
        const bool isLaserImmune = false;

        //Einfrieren bzw. Gefroren
        const float frozenMaxTime = 5.0f;
        
        //Anzünden bzw. Brennen
        const float burningMaxTime = 5.0f;
        const float burningDamage = 5.0f;

    }
}
