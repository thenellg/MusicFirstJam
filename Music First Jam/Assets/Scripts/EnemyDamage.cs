using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public GameObject spoils;

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

    void Die()
    {
        //Add in a death animation?
        //Instantiate(spoils, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
    }
}
