using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public static event Action PlayerDie;

    public int health, healthMax;

    private void Start()
    {
        health = healthMax;
    }


    public void GetDMG(int dmg)
    {
        health = health - dmg;
        if(health <= 0)PlayerDie?.Invoke();
    }
}
