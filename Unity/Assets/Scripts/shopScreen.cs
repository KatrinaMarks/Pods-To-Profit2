using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopScreen : MonoBehaviour
{
    /*
     * indecies:
     * 0 = all
     * 1 = seeds
     * 2 = fertilizers
     * 3 = field inspection
     * 4 = agrochemicals
     */
    public GameObject[] displayObjects = new GameObject[5];
    public Button[] displayButtons = new Button[5];
    public GameObject[] subdisplayObjects = new GameObject[3];
    public Button[] subdisplayButtons = new Button[3];
    public Sprite active;
    public Sprite inactive;
    int curIndex = 1;   // current index -- this needs to match the index of the starting display
    int curSubIndex = 0;   // current subdisplay index -- this needs to match the index of the starting subdisplay

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // the shop buttons call this to update the shop displays and button colors as needed
    public void updateDisplay(int index) {
        // hides the current display and changes the button back to inactive
        displayObjects[curIndex].SetActive(false);
        displayButtons[curIndex].image.sprite = inactive;
        // shows the new display and changes the button to active
        displayObjects[index].SetActive(true);
        displayButtons[index].image.sprite = active;
        // updates the current index so the next call hides the current display appropiately
        curIndex = index;
    }

    public void updateSubdisplay(int index) {
        // hides the current subdisplay and changes the button back to inactive
        subdisplayObjects[curSubIndex].SetActive(false);
        subdisplayButtons[curSubIndex].image.sprite = inactive;
        // shows the new subdisplay and changes the button to active
        subdisplayObjects[index].SetActive(true);
        subdisplayButtons[index].image.sprite = active;
        // updates the current index so the next call hides the current subdisplay appropiately
        curSubIndex = index;
    }
}
