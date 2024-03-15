using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageProgressBar : MonoBehaviour
{
    [SerializeField] private Image progBar;
    [SerializeField] private Color newColor;

    Color brown = new Vector4(74, 63, 58);
    Color green = new Vector4(113, 183, 78);

    public GameObject statusBar;
    Renderer barRenderer; // = statusBar.GetComponent<renderer>();
    public bool colorShift = false;

    float timeLeft;
    Color targetColor;

    // Start is called before the first frame update
    void Start()
    {
        barRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (timeLeft <= Time.deltaTime)
        // {
        //     // transition complete
        //     // assign the target color
        //     renderer.material.color = targetColor;
        
        //     // start a new transition
        //     targetColor = new Color(Random.value, Random.value, Random.value);
        //     timeLeft = 1.0f;
        // }
        // else
        // {
        //     // transition in progress
        //     // calculate interpolated color
        //     renderer.material.color = Color.Lerp(renderer.material.color, targetColor, Time.deltaTime / timeLeft);
        
        //     // update the timer
        //     timeLeft -= Time.deltaTime;
        // }


        // newColor = Color.Lerp(brown, green, Mathf.PingPong(Time.deltaTime, 1));
        // progBar.color = newColor;
        // if (colorShift) changeColor();
    }


    void changeColor() {
        // progBar.color = brown;
        progBar.color = Color.Lerp(brown, green, Mathf.PingPong(Time.time, 1));
        // barRenderer.material.color = Color.Lerp(brown, green, Mathf.PingPong(Time.time, 1));
    }
}
