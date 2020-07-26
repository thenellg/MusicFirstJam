using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public GameObject spoils;
    public int damageToPlayer = 0;
    public bool inArena = false;
    GameObject arena;


    public void Start()
    {
        Debug.Log(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        Debug.Log(health);
    }

    public void Die()
    {
        //Add in a death animation?
        //Instantiate(spoils, transform.position, Quaternion.identity);

        if (inArena)
            arena.GetComponent<FightArena>().enemiesKilled++;

        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
        if (collision.gameObject.tag == "Arena")
        {
            arena = collision.gameObject;
        }
    }
}
