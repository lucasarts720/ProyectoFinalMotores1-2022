using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionStamina : PotionBase
{
    public int percentageBonus;
    protected override void PotionEffect()
    {
        playermovement.staminaMax *= (percentageBonus/100);
    }
}
