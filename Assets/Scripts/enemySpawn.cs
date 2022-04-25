using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    private int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        numEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(numEnemies < 25)
        {
            if (!IsInvoking())
            {
                Invoke("spawnEnemy", 5.0f);
            }
        }
    }

    void enemyKilled()
    {
        numEnemies--;
    }

    void spawnEnemy()
    {
        GameObject newEnemy = Resources.Load<GameObject>("Prefabs/enemy");

        newEnemy = Instantiate(newEnemy);

        newEnemy.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(6.0f, 1.0f), 32);

        numEnemies++;
    }
}
