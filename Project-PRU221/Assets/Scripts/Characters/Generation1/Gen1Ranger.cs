using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1Ranger : Gen1Soldier
{
    void Awake()
    {
        maxHealth = 50;
        damage = 20;
        attackRange = 8f;
        timeBetweenHit = 1f;
        cost = 50;
    }
}
