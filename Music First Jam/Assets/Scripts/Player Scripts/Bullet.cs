using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] private List<string> tagExclusionList;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("destruction",2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag != "Player" && collision.tag != "Arena")
            if (!tagExclusionList.Contains(collision.tag)){
            destruction();
        }
    }

    private void destruction()
    {
        Destroy(gameObject);
    }

}
