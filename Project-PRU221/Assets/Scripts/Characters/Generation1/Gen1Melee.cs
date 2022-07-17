using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1Melee : Gen1Soldier
{
    void Awake()
    {
        maxHealth = 100;
        damage = 15;
        attackRange = 2f;
        timeBetweenHit = 1f;
        cost = 50;
    }
}
