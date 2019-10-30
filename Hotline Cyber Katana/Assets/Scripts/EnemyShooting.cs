using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject Bullet;
    bool allowfire = true;
    public float ScaleRateOFFire;

    private void Update()
    {
        if (true)
        {

        }
    }
    public void Shoot()
    {
        if(allowfire)
        {

        allowfire = false;
        Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(RateOfFire());

        }
    }
    IEnumerator RateOfFire()
    {
        yield return new WaitForSeconds(ScaleRateOFFire);
        allowfire = true;
    }
}
