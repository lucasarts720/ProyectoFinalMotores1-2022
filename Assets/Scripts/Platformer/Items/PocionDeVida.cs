using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocionDeVida : PotionBase
{
    protected override void PotionEffect()
    {
        player.health = player.healthMax;
    }

}
