using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolMenu : MonoBehaviour
{
    //public Rigidbody2D toolMenuExtension;
    public GameObject bioPestSlider;
    public GameObject rhizoSlider;
    public GameObject fertSlider;

    // true means extended, false means collapsed (hidden)
    public bool menuBool = true;    
    public bool bioPestBool = false; 
    public bool rhizoBool = false; 
    public bool fertBool = false; 
    // 0 = bioPest ; 1 = rhizo ; 2 = fert
    public bool[] invBools;
    public GameObject[] sliders;

    public int index = 0;

    public float moveSpeed = 500;   // simply how fast the tool menu moves up/down

    // public Button rhizoButton;
    // public Button bioPestButton;
    // public Button fertButton;

    
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
        sliders[0] = bioPestSlider;
        sliders[1] = rhizoSlider;
        sliders[2] = fertSlider;
        invBools[0] = false;
        invBools[1] = false;
        invBools[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the tool menu extension up/down depending on the status of menuBool
        if (menuBool == false && transform.position.y > -62) {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        } else if (menuBool == true && transform.position.y < 248) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        // if (invBools[index] == false && sliders[index].transform.localPosition.x < 1033) {
        //     sliders[index].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        // } else if (invBools[index] == true && sliders[index].transform.localPosition.x > 595) {
        //     sliders[index].transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        // }
    }

    public void toggleMenu() {
        menuBool = !menuBool;
    }

    public void toggleInventoryBool(int i) {
        invBools[i] = !invBools[i];
        index = i;
    }

    public void toggleBioPest() {
        bioPestBool = !bioPestBool;
    }

    public void toggleRhizo() {
        menuBool = !menuBool;
    }

    public void toggleFert() {
        menuBool = !menuBool;
    }

}
