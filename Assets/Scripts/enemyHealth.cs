using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public float health;

    private int originalHealth;

    private enemyController enemyControl;

    private enemySpawn spawner;

    private shop playerStats;

    // Start is called before the first frame update
    void Start()
    {
        enemyControl = GameObject.Find("enemyController").GetComponent<enemyController>();

        spawner = GameObject.Find("enemySpawner").GetComponent<enemySpawn>();

        playerStats = Camera.main.gameObject.GetComponent<shop>();

        health = Random.Range(1, enemyControl.currentLevel);

        originalHealth = (int)health;
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
    }

}
