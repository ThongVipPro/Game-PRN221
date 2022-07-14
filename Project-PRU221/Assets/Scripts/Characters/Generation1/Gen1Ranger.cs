using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1Ranger : Gen1Soldier
{
    void Awake()
    {
        maxHealth = 50;
        damage = 20;
        attackRange = 5f;
        timeBetweenHit = 2f;
        cost = 50;
    }
}
