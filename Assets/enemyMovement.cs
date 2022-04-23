using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    Vector3 currentPosition;

    Vector3 targetPosition;

    [SerializeField]
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = gameObject.transform.position;
        targetPosition = target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPosition.z <= targetPosition.z)
        {
            SendMessage("ResetHealth");
        }

        currentPosition = Vector3.MoveTowards(currentPosition, currentPosition - new Vector3(0.0f, 0.0f, 0.2f), 0.2f);
    }
}
