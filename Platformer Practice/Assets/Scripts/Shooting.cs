using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!canShoot)
            {
                return;
            }

            GameObject si = Instantiate(shootingItem, shootingPoint);
            si.transform.parent = null;
        }
    }

    void Shoot()
    {

    }
}
