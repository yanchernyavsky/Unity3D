using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject Bullet;
    bool allowfire = true;
    public float ScaleRateOFFire;
    void Update()
    {
        if (Input.GetButton("Fire1") && (allowfire))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Time.timeScale = 0.3f;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Time.timeScale = 1f;
        }

    }

    void Shoot()
    {
        allowfire = false;
        Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(RateOfFire());
        
    }
    IEnumerator RateOfFire()
    {
        yield return new WaitForSeconds(ScaleRateOFFire);
        allowfire = true;
    }
}
