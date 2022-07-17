using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1Cavalry : Gen1Soldier
{
    void Awake()
    {
        maxHealth = 200;
        damage = 20;
        attackRange = 2f;
        timeBetweenHit = 3f;
        cost = 100;
    }
}
