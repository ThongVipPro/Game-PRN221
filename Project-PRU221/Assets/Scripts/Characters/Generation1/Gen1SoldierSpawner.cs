using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gen1SoldierSpawner : SoldierSpawner
{
    private void Awake()
    {
        maxHealth = 2000;
    }

    public override void SpawnCavalry()
    {
        var cavalryGameObject = Resources.Load("Prefabs/Gen1Cavalry") as GameObject;
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
            else if (cavalryGameObject.layer == 6)
            {
                cavalryGameObject.transform
                    .GetChild(0)
                    .GetChild(0)
                    .GetChild(1)
                    .GetComponent<Image>()
                    .color = Color.green;
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
        var meleeGameObject = Resources.Load("Prefabs/Gen1Melee") as GameObject;
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
            else if (meleeGameObject.layer == 6)
            {
                meleeGameObject.transform
                    .GetChild(0)
                    .GetChild(0)
                    .GetChild(1)
                    .GetComponent<Image>()
                    .color = Color.green;
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
        var rangerGameObject = Resources.Load("Prefabs/Gen1Ranger") as GameObject;
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
            else if (rangerGameObject.layer == 6)
            {
                rangerGameObject.transform
                    .GetChild(0)
                    .GetChild(0)
                    .GetChild(1)
                    .GetComponent<Image>()
                    .color = Color.green;
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
