using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Rigidbody2D rb;
    public int velocidad, health, healthMax;
    public Transform cannon;
    public Projectil projectil;
    public SpaceShipsManager lm;
    public bool isShielded = true;
    public GameObject shield;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType <SpaceShipsManager>();
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (health <= 0)
        {
            Die();
        }
    }
    
    void Movimiento()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movimiento = new Vector2(inputX, inputY);
        rb.transform.Translate(movimiento * velocidad * Time.deltaTime);
    }

    void Shoot()
    {
        Instantiate(projectil, cannon.position, transform.rotation);
    }

    public void GetDMG(int dmg)
    {
        if (isShielded)
        {
            shield.gameObject.SetActive(false);
            isShielded = !isShielded;
        }
        else
        {
            health = health - dmg;
        }
    }
    void Die()
    {
        lm.EndGame();
    }
}
