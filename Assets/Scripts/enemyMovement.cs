using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    Vector3 currentPosition;

    Vector3 targetPosition;

    Transform target;

    private enemySpawn spawner;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.gameObject.transform;

        spawner = GameObject.Find("enemySpawner").GetComponent<enemySpawn>();

        targetPosition = target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = gameObject.transform.position;

        if (currentPosition.z <= targetPosition.z)
        {

            spawner.SendMessage("enemyKilled");
            Destroy(gameObject);
        }

        currentPosition = Vector3.MoveTowards(currentPosition, currentPosition - new Vector3(0.0f, 0.0f, 0.6f), 0.6f);
    }
}
