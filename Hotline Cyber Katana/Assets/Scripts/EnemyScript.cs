using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float Detection = 15f;
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField]
    private EnemyShooting enemyShooting;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Detection);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(Vector3.Distance(player.transform.position, transform.position));
        if (Vector3.Distance(player.transform.position, transform.position) <= Detection)
        {
            Vector2 LookDirection = (Vector2)player.transform.position - rb.position;
            float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            enemyShooting.Shoot();
        }

        
    }

    public void EnemyDeath()
    {
        Destroy(gameObject, 0.2f);
    }
}
