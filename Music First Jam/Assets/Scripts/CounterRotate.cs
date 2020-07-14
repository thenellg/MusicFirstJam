using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterRotate : MonoBehaviour
{
    public GameObject currObject;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 0f);
    }
}
