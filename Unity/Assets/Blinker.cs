using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    public GameObject shopButton;
    public Image image;
    public float currentImageColorAlpha = 0.5f;

    public float duration = 5f;

    
    // Start is called before the first frame update
    void Start()
    {
        image = shopButton.GetComponent<Image>();
        //Get the alpha value of Color
		currentImageColorAlpha = image.color.a;
        //Color c = i.color;
        //c.a = 0f;
        //i.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        var startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + duration)
        {
            //image.color.a = 0f;
        }
        
    }
}
