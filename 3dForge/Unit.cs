using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3dForge
{

    public class Unit:MonoBehaviour
    {  
        public enum DamageType { Physical, Fire, Ice, Wind, Earth,Laser }; //Sollte in die GameProperties rein....
    
        //Monster Maximal Werte
        const float maxHealth = 100.0f;
        const float maxResistance = 10.0f; //Wiederstand, wird von allem körperlichen Standen abgezogen und verbraucht sich nicht.
        const float maxShield = 100.0f;
        const float maxArmor = 100.0f;        
        const float maxSpeed = 10.0f; //Wer macht die Einheitenbewegung?

        //Enviroment Werte
        const string name = "Monster";
        const float money = 1.0f; 
        const float experience = 10.0f;
        const int killsPlayerLivePoints = 1;


        //Aktuelle Werte
        float curHealth;
        float curArmor;
        float curShield;
        float curSpeed;

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
        bool isFrozen = false;
        float frozenTimer = 0.0f;
        const float frozenMaxTime = 5.0f;

        //Anzünden bzw. Brennen
        bool isBurning = false;
        float burningTimer = 0.0f;
        const float burningDamage = 5.0f;
        const float burningMaxTime = 5.0f;

        void Awake()
        {
            curHealth = maxHealth;
            curShield = maxShield;
            curArmor = maxArmor;
            curSpeed = maxSpeed;
        }

        void Update()
        {
            Frozen();

            Burning();
            
            Regeneration();

        }

        private void Frozen()
        {          
            if (frozenTimer > 0 && isFrozen ==  false) //Freezing
            {
                isFrozen = true;
                curSpeed = maxSpeed / 2;
            }
            else if (frozenTimer > 0 && isFrozen) //Frozen
            {
                frozenTimer = Mathf.Clamp(frozenTimer - (1.0f*Time.deltaTime), 0, frozenMaxTime);
            }
            else if (frozenTimer == 0 && isFrozen == true) //DeFrost
            {
                curSpeed = maxSpeed;
                isFrozen = false;
            }           
        }

        private void Burning()
        {
            if (burningTimer > 0 && isBurning == false) //Freezing
            {
                isBurning = true;
                CalcDamage(DamageType.Fire, (burningDamage*Time.deltaTime));
            }
            else if (burningTimer > 0 && isBurning) //burning
            {
                burningTimer = Clamp(burningTimer - (1.0f * Time.deltaTime), 0, burningMaxTime);
                CalcDamage(DamageType.Fire, (burningDamage*Time.deltaTime));
            }
            else if (burningTimer == 0 && isBurning == true) //DeFrost
            {
                isBurning = false;
            }
        }

        private void Regeneration()
        {
            if (curHealth != maxHealth && healthRegeneration >0) curHealth = Mathf.Clamp(curHealth + healthRegeneration, 0, maxHealth);
            if (curShield != maxShield && shieldRegeneration > 0) curShield = Mathf.Clamp(curShield + shieldRegeneration, 0, maxShield);
            if (curArmor != maxArmor && armorRegeneration >0 ) curArmor = Mathf.Clamp(curArmor + armorRegeneration, 0, maxArmor);
        }



        public void GetDamage(DamageType damageType, float damage)
        {
            if (
                (damageType == DamageType.Physical && isPhysicalImmune) ||
                (damageType == DamageType.Fire && isFireImmune) ||
                (damageType == DamageType.Ice && isIceImmune) ||
                (damageType == DamageType.Wind && isWindImmune) ||
                (damageType == DamageType.Earth && isEarthImmune) ||
                (damageType == DamageType.Laser && isLaserImmune)
                )
            {
                damage = 0f;
            }
            else if (
                    (damageType == DamageType.Physical && isPhysicalResist) ||
                    (damageType == DamageType.Fire && isFireResist) ||
                    (damageType == DamageType.Ice && isIceResist) ||
                    (damageType == DamageType.Wind && isWindResist) ||
                    (damageType == DamageType.Earth && isEarthResist) ||
                    (damageType == DamageType.Laser && isLaserResist)
                )
            {
                damage /= 2;
            }

            /*
            
             */
            //Einfrieren
            if (damageType == DamageType.Ice) frozenTimer = frozenMaxTime;

            //Brennen
            if (damageType == DamageType.Fire) burningTimer = burningMaxTime;

            //WInd ? Keine Ahnung was besonders ist
            if (damageType == DamageType.Wind) {;}

            //Erde ? Keine Ahnung was besonders ist
            if (damageType == DamageType.Earth) { ;}

            CalcDamage(damageType, damage);
            
        }

        private void CalcDamage(DamageType damageType, float damage)
        {
            //Schadensberechnung Shild
            if (damageType != DamageType.Laser) //Laser ignoriert Schild
            {
                float damageToShield = Mathf.Clamp(damage, 0, curShield);
                damage -= damageToShield;
                curShield -= damageToShield;
            }

            //Schadensberechnung Rüstung
            float damageToArmor = Mathf.Clamp(damage, 0, curArmor);
            damage -= damageToArmor;
            curArmor -= damageToArmor;

            //Wiederstand
            damage -= Mathf.Clamp(damage - maxResistance, 0, damage);

            //Schadensberechnung Normal
            curHealth -= Mathf.Clamp(damage, 0, curHealth);


            ///*
            if (curHealth <= 0) GameObject.Destroy(gameObject);
            
            //GameProperties.money += money;
            //GameProperties.experience += experience;
            //*/
        }

        private float Clamp(float value, float min, float max)
        {
            if (min > max) { return value; } //Error min darf nicht größer als Max sein.

            if (value > max) return max;
            if (value < min) return min;

            return value;

        }
    }
}
