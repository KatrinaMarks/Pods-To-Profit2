using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolMenu : MonoBehaviour
{
    //public Rigidbody2D toolMenuExtension;
    public bool toggled = false;
    // RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(transform.position);
    }

    // Update is called once per frame

    void Update()
    {
        
    }

    public void toggleMenu() {
        if (toggled) {
            toggled = false;
            transform.position = new Vector3(985, 248, 0);
            // Debug.Log("true");
        } else {
            toggled = true;
            transform.position = new Vector3(985, -350, 0);
            // Debug.Log("false");
        }
    }

}
