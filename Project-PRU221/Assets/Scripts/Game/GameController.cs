using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    Timer timer;

    GameObject myHouse;
    GameObject enemyHouse;

    UpGeneration upGeneration = new UpGeneration();

    // Start is called before the first frame update
    void Start()
    {
        myHouse = GameObject.Find("MyHouse");
        enemyHouse = GameObject.Find("EnemyHouse");
        myHouse.AddComponent<Gen1SoldierSpawner>();
        enemyHouse.AddComponent<Gen1SoldierSpawner>();

        // Initiates timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(3, 7);
        timer.Run();

        EventManager.AddPurchaseSuccessfulListener(Buy);
        EventManager.AddUpGenerationInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            if (Random.Range(0, 3) == 0)
            {
                enemyHouse.GetComponent<SoldierSpawner>().SpawnMelee();
                //myHouse.GetComponent<SoldierSpawner>().SpawnMelee();
            }
            else if (Random.Range(0, 3) == 1)
            {
                enemyHouse.GetComponent<SoldierSpawner>().SpawnRanger();
                //myHouse.GetComponent<SoldierSpawner>().SpawnRanger();
            }
            else
            {
                enemyHouse.GetComponent<SoldierSpawner>().SpawnCavalry();
                //myHouse.GetComponent<SoldierSpawner>().SpawnCavalry();
            }
            timer.Duration = Random.Range(3, 7);
            timer.Run();
        }
    }

    public void Buy(int i)
    {
        if (i == 0)
        {
            //enemyHouse.GetComponent<SoldierSpawner>().SpawnMelee();
            myHouse.GetComponent<SoldierSpawner>().SpawnMelee();
        }
        else if (i == 1)
        {
            //enemyHouse.GetComponent<SoldierSpawner>().SpawnRanger();
            myHouse.GetComponent<SoldierSpawner>().SpawnRanger();
        }
        else if (i == 2)
        {
            //enemyHouse.GetComponent<SoldierSpawner>().SpawnCavalry();
            myHouse.GetComponent<SoldierSpawner>().SpawnCavalry();
        }
        else if (i == 3)
        {
            Destroy(myHouse.GetComponent<Gen1SoldierSpawner>());
            myHouse.AddComponent<Gen2SoldierSpawner>();
            upGeneration.Invoke();
        }
    }

    public void AddUpGenerationListener(UnityAction listener)
    {
        upGeneration.AddListener(listener);
    }
}
