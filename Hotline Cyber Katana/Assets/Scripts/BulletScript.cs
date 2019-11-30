using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public GameObject SparksPrefab;
    public GameObject BloodSplat;
    GameObject _bloodSplat;
    GameObject sparks;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject, 3f);
    }

    void FixedUpdate()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sparks = Instantiate(SparksPrefab, transform.position, transform.rotation);
        Destroy(sparks, 0.3f);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().EnemyDeath();
            _bloodSplat = Instantiate(BloodSplat, collision.transform.position,Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z+50f));
            _bloodSplat.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Death();
            _bloodSplat = Instantiate(BloodSplat, collision.transform);
            _bloodSplat.transform.parent = null;


        }
    }
}
