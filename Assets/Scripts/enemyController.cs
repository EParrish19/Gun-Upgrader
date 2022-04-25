using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public int currentLevel;

    private float timeThreshhold;

    private float timeSinceLastincrease;

    private bool maxLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        timeThreshhold = 60.0f;
        timeSinceLastincrease = 0.0f;
        maxLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!maxLevel) {
            timeSinceLastincrease += Time.deltaTime;

            if (timeSinceLastincrease >= timeThreshhold)
            {
                currentLevel += 1;
    
            if (currentLevel == 100) {
                    maxLevel = true;
                }
            }
        }
    }
}
