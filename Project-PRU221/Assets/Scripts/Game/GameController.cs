using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Timer timer;

    GameObject myHouse;
    GameObject enemyHouse;

    // Start is called before the first frame update
    void Start()
    {
        myHouse = GameObject.FindGameObjectWithTag("P1");
        enemyHouse = GameObject.FindGameObjectWithTag("P2");
        myHouse.AddComponent<Gen1SoldierSpawner>();
        enemyHouse.AddComponent<Gen1SoldierSpawner>();

        // Initiates timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(3, 7);
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            if (Random.Range(0, 3) == 0)
            {
                enemyHouse.GetComponent<SoldierSpawner>().SpawnMelee();
            }
            else if (Random.Range(0, 3) == 1)
            {
                enemyHouse.GetComponent<SoldierSpawner>().SpawnRanger();
            }
            else
            {
                enemyHouse.GetComponent<SoldierSpawner>().SpawnCavalry();
            }
            timer.Duration = Random.Range(3, 7);
            timer.Run();
        }
    }
}
