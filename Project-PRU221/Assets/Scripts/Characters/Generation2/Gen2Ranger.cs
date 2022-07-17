using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen2Ranger : Gen2Soldier
{
    void Awake()
    {
        maxHealth = 100;
        damage = 40;
        attackRange = 8f;
        timeBetweenHit = 1f;
        cost = 100;
    }
}
