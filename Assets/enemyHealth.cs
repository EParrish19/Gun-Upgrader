using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public float health;

    [SerializeField]
    private enemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(1, enemyController.currentLevel);
    }

    void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0.0f)
        {

        }
    }
}
