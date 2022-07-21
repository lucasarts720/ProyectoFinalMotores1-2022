using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    Rigidbody2D rb;
    public int health, speed, dmg;
    public SpaceShipsManager lm;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType<SpaceShipsManager>();
        health = 10;
    }
    private void Update()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    public void GetDMG(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        lm.kills +=1;
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            PlayerShip s_player = collision.gameObject.GetComponent<PlayerShip>();
            s_player.GetDMG(dmg);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
