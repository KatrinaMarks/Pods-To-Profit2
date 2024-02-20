using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //rotateArrow();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rotateArrow(float temp) {
        float angle = 43 - (temp * (float)1.8);
        transform.Rotate(Vector3.forward, angle, Space.Self);
    }
}
