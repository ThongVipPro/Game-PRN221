using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen2Melee : Gen2Soldier
{
    void Awake()
    {
        maxHealth = 200;
        damage = 30;
        attackRange = 2f;
        timeBetweenHit = 2f;
        cost = 100;
    }
}
