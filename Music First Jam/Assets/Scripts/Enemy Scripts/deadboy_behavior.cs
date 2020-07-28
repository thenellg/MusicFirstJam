using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadboy_behavior : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    [SerializeField] private float speed;
    void Start(){
        Invoke("Die",3f);
    }
    void Update()
    {
       transform.Translate(transform.up*Time.deltaTime * speed);
    }

    void Die(){
        Destroy(this.gameObject);
    }
}
