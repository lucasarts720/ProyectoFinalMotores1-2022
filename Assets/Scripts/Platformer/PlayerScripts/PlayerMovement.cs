using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Speed")]
    public int speed;
    [Header("Stamina")]
    public int stamina;
    public int staminaMax;
    public int staminaRegen;
    [Header("Dash")]
    public int dashSpeed;
    public int dashConsumption;
    public int dashMin;
    public int dashLenght;
    [Header("Jump")]
    public int jumpHeight;
    public int jumpConsumption;
    public int jumpMin;
    SpriteRenderer sr;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        jumpMin = jumpConsumption;
        dashMin = dashConsumption;
    }

    void Update()
    {
        StaminaRegen();
        Movement();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Jump()
    {
        if (stamina > jumpMin)
        {
            rb.velocity = new Vector2(0, jumpHeight);
            stamina = stamina - jumpConsumption;
        }
    }

    private void StaminaRegen()
    {
        if (stamina < staminaMax) stamina = (int)(stamina + (staminaRegen * Time.deltaTime * 2));
        else if (stamina > staminaMax) stamina = staminaMax;
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(inputX, 0, 0);
        rb.transform.Translate(movement * speed * Time.deltaTime);

        if (inputX > 0)
        {
            sr.flipX = false;
        }
        if (inputX < 0)
        {
            sr.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > dashMin)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-dashSpeed, dashLenght / 4);
                stamina = stamina - dashConsumption;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(dashSpeed, dashLenght / 4);
                stamina = stamina - dashConsumption;
            }

        }
    }
}
