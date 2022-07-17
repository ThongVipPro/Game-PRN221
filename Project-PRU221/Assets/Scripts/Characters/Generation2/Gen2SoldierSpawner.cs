using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gen2SoldierSpawner : SoldierSpawner
{
    private void Awake()
    {
        maxHealth = 4000;
    }

    public override void SpawnCavalry()
    {
        var cavalryGameObject = Resources.Load("Prefabs/Gen2Cavalry") as GameObject;
        if (cavalryGameObject != null)
        {
            cavalryGameObject.layer = gameObject.layer;
            if (cavalryGameObject.layer == 7)
            {
                cavalryGameObject.transform
                    .GetChild(0)
                    .GetChild(0)
                    .GetChild(1)
                    .GetComponent<Image>()
                    .color = Color.yellow;
            }
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
        var meleeGameObject = Resources.Load("Prefabs/Gen2Melee") as GameObject;
        if (meleeGameObject != null)
        {
            meleeGameObject.layer = gameObject.layer;
            if (meleeGameObject.layer == 7)
            {
                meleeGameObject.transform
                    .GetChild(0)
                    .GetChild(0)
                    .GetChild(1)
                    .GetComponent<Image>()
                    .color = Color.yellow;
            }
            var melee = Instantiate(meleeGameObject.transform, housePosition, Quaternion.identity);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void SpawnRanger()
    {
        var rangerGameObject = Resources.Load("Prefabs/Gen2Ranger") as GameObject;
        if (rangerGameObject != null)
        {
            rangerGameObject.layer = gameObject.layer;
            if (rangerGameObject.layer == 7)
            {
                rangerGameObject.transform
                    .GetChild(0)
                    .GetChild(0)
                    .GetChild(1)
                    .GetComponent<Image>()
                    .color = Color.yellow;
            }
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
