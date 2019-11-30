using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject Bullet;
    bool allowfire = true;
    public float ScaleRateOFFire;
    public int ammo = 20;

    public void Shoot()
    {
        if (allowfire)
            if (ammo > 0)
            {


                {

                    allowfire = false;
                    Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                    gameObject.GetComponent<AudioSource>().Play();
                    ammo--;
                    StartCoroutine(RateOfFire());

                }
            }
            else Reload();
    }
    void Reload()
    {
        ammo = 20;
    } 

    IEnumerator RateOfFire()
    {
        yield return new WaitForSeconds(ScaleRateOFFire);
        allowfire = true;
    }
}
