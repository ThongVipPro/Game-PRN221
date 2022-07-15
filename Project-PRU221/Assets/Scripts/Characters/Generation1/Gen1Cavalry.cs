using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1Cavalry : Gen1Soldier
{
    void Awake()
    {
        maxHealth = 200;
        damage = 20;
        attackRange = 4f;
        timeBetweenHit = 5f;
        cost = 100;
    }
}
