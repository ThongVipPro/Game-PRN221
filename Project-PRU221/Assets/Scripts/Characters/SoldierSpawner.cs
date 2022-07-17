using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SoldierSpawner : MonoBehaviour
{
    int health;
    protected int maxHealth = 0;

    HealthBar healthBar;

    protected Vector3 housePosition;

    public abstract void SpawnMelee();

    public abstract void SpawnRanger();

    public abstract void SpawnCavalry();

    private void Start()
    {
        healthBar = transform.GetChild(0).GetChild(0).GetComponent<HealthBar>();
        if (gameObject.layer == LayerMask.NameToLayer("P1"))
        {
            housePosition = transform.position + transform.right * 2;
        }
        else if (gameObject.layer == LayerMask.NameToLayer("P2"))
        {
            housePosition = transform.position - transform.right * 2;
        }
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void UpdateHealth(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            health = 0;
            StartCoroutine(Dead());
        }
        healthBar.SetHealth(health);
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //gameObject.SetActive(false);

    }
}
