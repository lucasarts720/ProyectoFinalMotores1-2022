using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    Rigidbody2D rb;
    public int dmg = 5, speed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(speed,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyShip s_enemy = collision.gameObject.GetComponent<EnemyShip>();
            s_enemy.GetDMG(dmg);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Mother"))
        {
            MOTHER s_enemy = collision.gameObject.GetComponent<MOTHER>();
            s_enemy.GetDMG(dmg);
            Destroy(this.gameObject);
        }
    }
}
