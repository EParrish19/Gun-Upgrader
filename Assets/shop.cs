using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    private float money = 0;

    private float damageCost = 10.0f;

    private float fireRateCost = 10.0f;

    private int weaponIndex;

    class playerWeapon
    {
        float baseDamage;
        string weaponName;
        bool isFinalWeapon;
        float fireRate;
        int numUpgrades;

        public playerWeapon(string name, float damage, float newFireRate, int upgrades, bool finalWeapon)
        {
            baseDamage = damage;
            weaponName = name;
            fireRate = newFireRate;
            numUpgrades = upgrades;
            isFinalWeapon = finalWeapon;
        }
    }

    private playerWeapon[] weapons = new playerWeapon[4];

    private playerWeapon pistol = new playerWeapon("pistol", 1.0f, 1.0f, 10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addMoney(float earnedMoney)
    {
        money += earnedMoney;
    }

    void upgradeDamage()
    {
        if(money >= damageCost)
        {
            //increase damage of player weapon
        }

        damageCost += damageCost / 4;
    }

    void upgradeFireRate()
    {
        if(money >= fireRateCost)
        {
            //increase fire rate of player weapon
        }
    }
}
