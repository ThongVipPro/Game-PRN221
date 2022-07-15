using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1SoldierSpawner : SoldierSpawner
{
    public override void SpawnCavalry()
    {
        var cavalryGameObject = Resources.Load("Prefabs/Gen1Cavalry") as GameObject;
        if (cavalryGameObject != null)
        {
            cavalryGameObject.layer = gameObject.layer;
            var cavalry = Instantiate(
                cavalryGameObject.transform,
                housePosition,
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void SpawnMelee()
    {
        var meleeGameObject = Resources.Load("Prefabs/Gen1Melee") as GameObject;
        if (meleeGameObject != null)
        {
            meleeGameObject.layer = gameObject.layer;
            var melee = Instantiate(meleeGameObject.transform, housePosition, Quaternion.identity);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void SpawnRanger()
    {
        var rangerGameObject = Resources.Load("Prefabs/Gen1Ranger") as GameObject;
        if (rangerGameObject != null)
        {
            rangerGameObject.layer = gameObject.layer;
            var ranger = Instantiate(
                rangerGameObject.transform,
                housePosition,
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}
