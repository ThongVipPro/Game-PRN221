using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Soldier : MonoBehaviour
{
    int health;
    protected int maxHealth = 0;
    bool isDead = false;

    float speed = 1.5f;
    Collider2D blocked;
    float keepDistance = 0.75f;

    public int damage = 0;
    Collider2D inCombat;
    protected float attackRange = 0;
    protected float timeBetweenHit = 0;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 6)
        {
            blocked = Physics2D.OverlapCircle(
                transform.position + transform.right * keepDistance,
                0.2f
            );
            inCombat = Physics2D.OverlapBox(
                transform.position + transform.right * (attackRange / 2),
                new Vector2(attackRange, 0.2f),
                0,
                7
            );
        }
        else if (gameObject.layer == 7)
        {
            blocked = Physics2D.OverlapCircle(
                transform.position - transform.right * keepDistance,
                0.2f
            );
            inCombat = Physics2D.OverlapBox(
                transform.position - transform.right * (attackRange / 2),
                new Vector2(attackRange, 0.2f),
                0,
                6
            );
        }
        Debug.Log(inCombat);
        // Lord forgives my sins for those nested if-else!
        if (blocked != null || isDead)
        {
            if (inCombat != null && !isDead)
            {
                if (timeBetweenHit <= attackCooldown)
                {
                    inCombat.gameObject.GetComponent<Soldier>().UpdateHealth(-damage);
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
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
