using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Soldier : MonoBehaviour
{
    int health;
    protected int maxHealth = 0;
    bool isDead = false;

    float speed = 1f;
    Collider2D blocked;
    float keepDistance = 0.5f;

    public int damage = 0;
    Collider2D inCombat;
    protected float attackRange = 0;
    protected float timeBetweenHit = 0;

    SoldierDied soldierDied = new SoldierDied();

    float attackCooldown;

    public int cost = 0;

    [SerializeField]
    HealthBar healthBar;

    public enum Generation
    {
        Gen1,
        Gen2
    }

    public abstract Generation GetGeneration();

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        EventManager.AddSoldierDiedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 6)
        {
            blocked = Physics2D.OverlapBox(
                transform.position + transform.right * (keepDistance / 2 + 1),
                new Vector2(keepDistance, 0.2f),
                0
            );
            inCombat = Physics2D.OverlapCircle(
                transform.position + transform.right * (attackRange / 2),
                attackRange / 2,
                LayerMask.GetMask("P2")
            );
        }
        else if (gameObject.layer == 7)
        {
            blocked = Physics2D.OverlapBox(
                transform.position - transform.right * (keepDistance / 2 + 1),
                new Vector2(keepDistance, 0.2f),
                0
            );
            inCombat = Physics2D.OverlapCircle(
                transform.position - transform.right * (attackRange / 2),
                attackRange / 2,
                LayerMask.GetMask("P1")
            );
        }

        // Lord forgives my sins for those nested if-else!
        if (blocked != null || isDead)
        {
            if (inCombat != null && !isDead)
            {
                if (timeBetweenHit <= attackCooldown)
                {
                    if (inCombat.gameObject.tag == "Player")
                    {
                        inCombat.gameObject.GetComponent<SoldierSpawner>().UpdateHealth(damage);
                        Debug.Log(damage);
                    }
                    else
                    {
                        inCombat.gameObject.GetComponent<Soldier>().UpdateHealth(damage);
                    }
                    attackCooldown = 0;
                }
                else
                {
                    attackCooldown += Time.deltaTime;
                }
            }
        }
        else
        {
            if (gameObject.layer == 6)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else if (gameObject.layer == 7)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
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
        isDead = true;
        if (gameObject.layer == 7)
        {
            soldierDied.Invoke(cost / 2);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void AddSoldierDiedListener(UnityAction<int> listener)
    {
        soldierDied.AddListener(listener);
    }
}
