using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toolMenu : MonoBehaviour
{
    // true means extended, false means collapsed (hidden)
    public bool menuBool = true;    
    public bool[] invBools;
    public GameObject[] sliders;

    public InventoryManager invMan;

    // Haven't decided if I want to move the logic for these here from InventoryManager
    // [Header("Slider Texts")]
    // public TMP_Text fertSlot1Text; 
    // public TMP_Text fertSlot2Text; 
    // public TMP_Text fertSlot3Text; 

    int index = 0; // 0 = pest ; 1 = seed ; 2 = fert
    public float moveSpeed = 500;   // simply how fast the tool menu moves up/down

    // The three x values for the sliders (pest, seed, & fert)

    int[] showNumPos = new int[3] {875, 735, 595};
    int pos;
    int showOne = 875;
    int showTwo = 735;
    int showThree = 595;

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
       
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the tool menu extension up/down depending on the status of menuBool
        if (menuBool == false && transform.position.y > -65) {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            // set all three to false to close the sliders
            invBools[0] = false;
            invBools[1] = false;
            invBools[2] = false;
            invMan.curSlider = -1;
        } else if (menuBool == true && transform.position.y < 248) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        if (invBools[index] == false) {
            // close slider at index
            if (sliders[index].transform.localPosition.x < 1033)    sliders[index].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            // close the other two if still open
            if (sliders[nextIndex(index)].transform.localPosition.x < 1033)             sliders[nextIndex(index)].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (sliders[nextIndex(nextIndex(index))].transform.localPosition.x < 1033)  sliders[nextIndex(nextIndex(index))].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        } else if (invBools[index] == true) {
            // checks sum of types to set how far to open the slider
            if (invMan.inventory[index][3] <= 1)        pos = showOne;
            else if (invMan.inventory[index][3] == 2)   pos = showTwo;
            else                                        pos = showThree;
            
            // open slider at index
            if (sliders[index].transform.localPosition.x > pos)     sliders[index].transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            // close the other two if still open
            if (sliders[nextIndex(index)].transform.localPosition.x < 1033)             sliders[nextIndex(index)].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (sliders[nextIndex(nextIndex(index))].transform.localPosition.x < 1033)  sliders[nextIndex(nextIndex(index))].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    public void toggleMenu() {
        menuBool = !menuBool;
    }

    // toggles slider at index, turns other two to false so they don't just reopen when Update() runs again
    public void toggleInventoryBool(int i) {
        invBools[i] = !invBools[i];
        invBools[nextIndex(i)] = false;
        invBools[nextIndex(nextIndex(i))] = false;
        index = i;
        invMan.curSlider = i;
    }

    // rotates the index from 0 -> 1 -> 2 -> 0 
    int nextIndex(int i){ 
        return (i + 1) % 3;
    }
}
