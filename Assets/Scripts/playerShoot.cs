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

    private void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        shootSpeed = 1.0f / playerStats.currentWeapon.currentFireRate;

        shotDamage = playerStats.currentWeapon.currentDamage;

        time += Time.deltaTime;

        if(time >= shootSpeed)
        {
            time = 0.0f;

            RaycastHit shot;

            Ray ray = Camera.main.ViewportPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out shot))
            {
                GameObject target = shot.transform.gameObject;

                if(target.name == "enemy")
                {
                    target.SendMessage("takeDamage", shotDamage);
                }
            }
        }


    }
}
