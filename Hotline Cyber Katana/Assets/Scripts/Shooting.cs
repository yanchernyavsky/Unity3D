using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject Bullet;
    bool allowfire = true;
    public float ScaleRateOFFire;
    public Text UIAmmo;
    public int ammo = 20;
    public AudioSource ReloadSound;
    public AudioSource ShootSound;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        UIAmmo.text = "20/"+ ammo;
        
    }

    public void Reload()
    {
        if (ammo != 20) ReloadSound.Play();
        ammo = 20;

    }

    public void Shoot()
    {
        if (ammo > 0)
        {

            allowfire = false;
            Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            ShootSound.Play();
            ammo--;
            StartCoroutine(RateOfFire());
        }
        //else Reload();
    }
    IEnumerator RateOfFire()
    {
        yield return new WaitForSeconds(ScaleRateOFFire);
        allowfire = true;
    }
}
