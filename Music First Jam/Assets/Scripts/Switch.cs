using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject connectedObject;
    public bool showingNewObject = true;
    public Sprite leverDown;

    // Start is called before the first frame update
    private void Start()
    {
        if (showingNewObject)
            connectedObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            //Can make this look much more fancy later

            if (showingNewObject)
                connectedObject.SetActive(true);
            else
                connectedObject.SetActive(false);

            GetComponent<SpriteRenderer>().sprite = leverDown;
        }
    }


}
