using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{

    public float health;

    private int originalHealth;

    private enemyController enemyControl;

    private enemySpawn spawner;

    private shop playerStats;

    private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        enemyControl = GameObject.Find("enemyController").GetComponent<enemyController>();

        spawner = GameObject.Find("enemySpawner").GetComponent<enemySpawn>();

        healthText = gameObject.GetComponentInChildren<Text>();

        playerStats = Camera.main.gameObject.GetComponent<shop>();

        health = Random.Range(1, enemyControl.currentLevel);

        originalHealth = (int)health;

        healthText.text = health.ToString();
    }

    void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0.0f)
        {
            spawner.SendMessage("enemyKilled");

            playerStats.SendMessage("addMoney", originalHealth);

            Destroy(gameObject);
        }
        else
        {
            healthText.text = health.ToString();
        }
    }

}
