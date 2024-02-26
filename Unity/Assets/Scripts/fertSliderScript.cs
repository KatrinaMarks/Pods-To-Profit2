using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class fertSliderScript : MonoBehaviour
{
    public bool toggled = true;    // true means collapsed (hidden), false means extended
    public float moveSpeed = 500;   // simply how fast the tool menu moves up/down

    public GameObject bioPestSlider;
    public GameObject rhizoSlider;
    public GameObject fertSlider;

    // // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (isMouseOver() == true) {
        //     toggleSlide;
        // }

        // Moves the tool menu extension up/down depending on the status of toggled
        if (toggled == true && fertSlider.transform.localPosition.x < 1033) {
            fertSlider.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        } else if (toggled == false && fertSlider.transform.localPosition.x > 595) {
            fertSlider.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    // public bool isMouseOver() {
    //     return EventSystem.current.IsPointerOverGameObject();
    // }

    // public void OnMouseOver()
    // {
    //     //If your mouse hovers over the GameObject with the script attached, output this message
    //     Debug.Log("Mouse is over GameObject.");
    //     toggleSlide();
    // }

    // public void OnMouseExit()
    // {
    //     //The mouse is no longer hovering over the GameObject so output this message each frame
    //     Debug.Log("Mouse is no longer on GameObject.");
    //     toggleSlide();
    // }

    public void toggleSlide() {
        toggled = !toggled;
    }

}
