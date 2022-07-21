using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOTHER : MonoBehaviour
{
    Rigidbody2D rb;
    public int health, speed, dmg;
    public GameObject[] Obstacles;
    public Transform[] spawnpoint;
    public int minWait;
    public int maxWait;
    int objToSpawn, actualSpawnPoint;
    public SpaceShipsManager lm;

    void Start()
    {
        StartCoroutine(spawntimer());
        rb = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType<SpaceShipsManager>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(-speed * 0.25f, 0);

        if (health <= 0)
        {
            Die();
        }
    }

    public void GetDMG(int dmg)
    {
        health -= dmg;
    }

    void Die()
    {
        lm.bossIsActive = false;
        lm.deathBoss = lm.deathBoss + 1;
        lm.SpawnerActivate();
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

    IEnumerator spawntimer()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        objToSpawn = Random.Range(0, Obstacles.Length);
        actualSpawnPoint = Random.Range(0, spawnpoint.Length);
        Instantiate(Obstacles[objToSpawn], spawnpoint[actualSpawnPoint]);
        StartCoroutine(spawntimer());
    }
}
