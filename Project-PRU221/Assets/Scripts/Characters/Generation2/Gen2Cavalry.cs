using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen2Cavalry : Gen2Soldier
{
    void Awake()
    {
        maxHealth = 400;
        damage = 40;
        attackRange = 2f;
        timeBetweenHit = 5f;
        cost = 200;
    }
}
