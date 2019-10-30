using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public GameObject SparksPrefab;
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
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

            enemy.EnemyDeath();
        }
    }
}
