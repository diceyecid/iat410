using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryArrow : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    //public GameObject impactEffect;


    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);

        SimpleEnemy enemy = collision.GetComponent<SimpleEnemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }


        //Instantiate(impactEffect, transform.position, transform.rotation);

        if (collision.gameObject.layer == 3)
            Destroy(gameObject);

    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer != 9 && collision.transform.gameObject.layer != 13 && collision.tag != "shield" && collision.transform.gameObject.layer != 3)
        {
            Destroy(gameObject);
        }
    }*/
}
