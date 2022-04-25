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

    private Text moneyCounter;

    public playerWeapon currentWeapon;

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
        weaponUpgradeButton.interactable = false;

        weapons[0] = pistol;
        weapons[1] = smg;
        weapons[2] = assaultRifle;
        weapons[3] = lmg;

        currentWeapon = weapons[weaponIndex];

        moneyCounter = GameObject.Find("Canvas").GetComponentInChildren<Text>();

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

        if(money >= fireRateCost && fireRateUpgrades < currentWeapon.numUpgrades)
        {
            if (currentWeapon.isFinalWeapon || fireRateUpgrades < currentWeapon.numUpgrades)
            {
                fireRateUpgradeButton.interactable = true;
            }
        }

        if(currentWeapon.weaponName != "LMG")
        {
            weaponUpgradeButton.enabled = true;

            if (money >= weaponUpgradeCost && damageUpgrades == currentWeapon.numUpgrades && fireRateUpgrades == currentWeapon.numUpgrades)
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

        moneyCounter.text = "Money: " + money;
    }

    public void upgradeDamage()
    {
        if(money >= damageCost)
        {
            currentWeapon.currentDamage += 0.2f;

            money -= damageCost;

            damageCost += damageCost / 4;

            damageUpgrades++;

            damageUpgradeButton.GetComponentInChildren<Text>().text = "Damage Upgrade Cost: " + damageCost;

            damageUpgradeButton.interactable = false;

            moneyCounter.text = "Money: " + money;
        }

        
    }

    public void upgradeFireRate()
    {
        if(money >= fireRateCost)
        {
            currentWeapon.currentFireRate += 0.2f;

            money -= fireRateCost;

            fireRateCost += fireRateCost / 4;

            fireRateUpgrades++;

            fireRateUpgradeButton.GetComponentInChildren<Text>().text = "Fire Rate Upgrade Cost: " + fireRateCost;

            fireRateUpgradeButton.interactable = false;

            moneyCounter.text = "money: " + money;
        }

        
    }

    public void upgradeWeapon()
    {
        if(money >= weaponUpgradeCost)
        {
            weaponIndex++;

            currentWeapon = weapons[weaponIndex];

            money -= weaponUpgradeCost;

            weaponUpgradeCost += weaponUpgradeCost / 4;

            weaponUpgradeButton.GetComponentInChildren<Text>().text = "Upgrade Weapon Cost: " + weaponUpgradeCost;

            weaponUpgradeButton.interactable = false;

            moneyCounter.text = "Money: " + money;
        }
    }
}
