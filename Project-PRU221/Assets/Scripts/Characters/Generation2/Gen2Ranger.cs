using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen2Ranger : Gen2Soldier
{
    void Awake()
    {
        maxHealth = 100;
        damage = 40;
        attackRange = 5f;
        timeBetweenHit = 2f;
        cost = 100;
    }
}
