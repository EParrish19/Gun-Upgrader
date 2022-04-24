using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    private float money = 0;

    private float damageCost = 10.0f;

    private float fireRateCost = 10.0f;

    private float weaponUpgradeCost = 200.0f;

    private int weaponIndex = 0;

    private int damageUpgrades = 0;
    private int fireRateUpgrades = 0;

    private playerWeapon currentWeapon;

    public playerWeapon pistol = new playerWeapon("Pistol", 0.5f, 0.5f, 5);
    public playerWeapon smg = new playerWeapon("SMG", 2.0f, 2.0f, 10);
    public playerWeapon assaultRifle = new playerWeapon("Assault Rifle", 4.0f, 6.0f, 20);
    public playerWeapon lmg = new playerWeapon("LMG", 10.0f, 15.0f);

    public playerWeapon[] weapons = new playerWeapon[4];

    [SerializeField]
    private Button damageUpgradeButton;

    [SerializeField]
    private Button fireRateUpgradeButton;

    [SerializeField]
    private Button weaponUpgradeButton;

    //class for base player weapons
    public class playerWeapon
    {   
        
        public float baseDamage;
        public string weaponName;
        public bool isFinalWeapon;
        public float baseFireRate;
        public int numUpgrades;

        public float currentDamage;
        public float currentFireRate;

        //pistol, smg, assault rifle
        public playerWeapon(string name, float damage, float fireRate, int upgrades)
        {
            baseDamage = damage;
            weaponName = name;
            baseFireRate = fireRate;
            numUpgrades = upgrades;
            isFinalWeapon = false;

            currentDamage = baseDamage;
            currentFireRate = baseFireRate;
        }

        //lmg
        public playerWeapon(string name, float damage, float fireRate)
        {
            baseDamage = damage;
            weaponName = name;
            baseFireRate = fireRate;
            numUpgrades = 0;
            isFinalWeapon = true;

            currentDamage = baseDamage;
            currentFireRate = baseFireRate;
        }
    }

    

    


    // Start is called before the first frame update
    void Start()
    {
        
        damageUpgradeButton.interactable = false;
        fireRateUpgradeButton.interactable = false;

        weapons[0] = pistol;
        weapons[1] = smg;
        weapons[2] = assaultRifle;
        weapons[3] = lmg;

        currentWeapon = weapons[weaponIndex];

    }

    // Update is called once per frame
    void Update()
    {
        if(money >= damageCost)
        {
            if (currentWeapon.isFinalWeapon || damageUpgrades < currentWeapon.numUpgrades)
            {
                damageUpgradeButton.interactable = true;
            }
        }

        if(money >= fireRateCost)
        {
            if (currentWeapon.isFinalWeapon || fireRateUpgrades < currentWeapon.numUpgrades)
            {
                fireRateUpgradeButton.interactable = true;
            }
        }

        if(currentWeapon.weaponName != "LMG")
        {
            weaponUpgradeButton.enabled = true;
            
            if(money >= weaponUpgradeCost)
            {
                weaponUpgradeButton.interactable = true;
            }
        }
        else
        {
            weaponUpgradeButton.enabled = false;
        }
    }

    void addMoney(float earnedMoney)
    {
        money += earnedMoney;
    }

    void upgradeDamage()
    {
        if(money >= damageCost)
        {
            currentWeapon.currentDamage += 0.2f;
        }

        damageCost += damageCost / 4;
    }

    void upgradeFireRate()
    {
        if(money >= fireRateCost)
        {
            currentWeapon.currentFireRate += 0.2f;
        }

        fireRateCost += fireRateCost / 4;
    }
}
