using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolMenu : MonoBehaviour
{
    //public Rigidbody2D toolMenuExtension;
    public bool toggled = false;    // true means collapsed (hidden), false means extended 
    public float moveSpeed = 500;   // simply how fast the tool menu moves up/down
    
    /* I have no idea how I got the coordinates for upPos and downPos, but when using 
     * transform.position = upPos or = downPos, these are the coordinates that made them
     * match the coordinates they actually needed to be, which are upPos2 and downPos2.
     * Since I implemented the transition in between the two positions, as seen in Update(),
     * these coordinates became obsolete, but for some reason I feel like I will need them 
     * later, potentially when I add the "pages" feateure to the tool menu, so here they are.
     * Side note, my idea is that one set of coordinates are local and the other global, or 
     * with respect to the parent, but I'm not sure and don't see a reason to figure it out.
    */
    // public Vector3 upPos = new Vector3(985, 248, 0);
    // public Vector3 downPos = new Vector3(985, -350, 0);
    // public Vector3 upPos2 = new Vector3(25, -290, 0);
    // public Vector3 downPos2 = new Vector3(25, -600, 0);
   
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the tool menu extension up/down depending on the status of toggled
        if (toggled == true && transform.position.y > -62) {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        } else if (toggled == false && transform.position.y < 248) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

    public void toggleMenu() {
        toggled = !toggled;
    }

}
