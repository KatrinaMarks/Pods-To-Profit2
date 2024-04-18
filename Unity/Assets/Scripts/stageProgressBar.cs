using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageProgressBar : MonoBehaviour
{
    public float duration = 10;
    float timeElapsed = 0;

    public Color lerpedColor;
    public Color brown; // = (74, 63, 58, 255);
    public Color green; // = (113, 183, 78, 255);
    public Image progBarImage;

    public float lerpedPos;
    float startPos = 445;
    float endPos = 773;
    public float[] positions = new float[10];
    int index = 0;
    public GameObject progBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (timeElapsed < duration) {
        //     float t = timeElapsed / duration;
        //     lerpedColor = Color.Lerp(brown, green, t);
        //     lerpedPos = Mathf.Lerp(startPos, endPos, t);
        //     timeElapsed += Time.deltaTime;
        // } else {
        //     lerpedColor = green;
        //     lerpedPos = endPos;
        // }

        // progBar.GetComponent<Image>().color = lerpedColor;
        // progBar.transform.localPosition = new Vector3(lerpedPos, progBar.transform.localPosition.y, 0);
        
        if (index >= 10) index -= 10;
        progBar.transform.localPosition = new Vector3(positions[index], progBar.transform.localPosition.y, 0);
        
        /*
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
        */
    }

    public void nextStage(int i) {
        index += i;
    }
}
