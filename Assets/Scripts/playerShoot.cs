using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

    [SerializeField]
    private shop playerStats;

    private float shootSpeed;

    private float shotDamage;

    private float time;

    private LineRenderer shotTracer;

    private void Start()
    {
        time = 0.0f;

        shotTracer = gameObject.GetComponent<LineRenderer>();

        shotTracer.startColor = Color.red;
        shotTracer.endColor = Color.red;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shootSpeed = 1.0f / playerStats.currentWeapon.currentFireRate;

        shotDamage = playerStats.currentWeapon.currentDamage;

        time += Time.deltaTime;

        if(time >= shootSpeed)
        {
            time = 0.0f;

            RaycastHit shot;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out shot))
            {

                Debug.DrawRay(ray.origin, ray.direction, Color.red);

                Vector3[] positions = new Vector3[2] { ray.origin, shot.transform.position };

                shotTracer.SetPositions(positions);
                Invoke("resetShotTracer", shootSpeed);

                GameObject target = shot.transform.gameObject;

                if(target.tag == "enemy")
                {
                    target.SendMessage("takeDamage", shotDamage);
                }
            }
        }


    }

    void resetShotTracer()
    {
       for(int i = 0; i < shotTracer.positionCount; i++)
        {
            shotTracer.SetPosition(i, new Vector3(0.0f, 0.0f, 0.0f));
        }
    }
}
