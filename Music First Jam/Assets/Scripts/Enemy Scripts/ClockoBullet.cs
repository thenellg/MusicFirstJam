using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockoBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] private float decayRate = 2f;
    [SerializeField] private List<string> tagExclusionList;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("destruction",decayRate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!tagExclusionList.Contains(collision.tag)){
            destruction();
        }
    }

    private void destruction()
    {
        Destroy(gameObject);
    }

}
