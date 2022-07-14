using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierSpawner : MonoBehaviour
{
    public Transform houseTransform;

    public abstract void SpawnMelee();

    public abstract void SpawnRanger();

    public abstract void SpawnCavalry();
}
