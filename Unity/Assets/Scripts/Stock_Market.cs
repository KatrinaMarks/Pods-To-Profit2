using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stock_Market : MonoBehaviour
{
    public float stock_value = 0;
    // maximum value: minimum valve:
    public float delta = 0;
    public float min_delta = -0.15F;
    public float max_delta = 0.15F;
    // maximum value: (never be negative)
    public float variance = 0;
    public float max_variance = 0.1F;
    void Start()
    {
        initial_stock (1.5F, 0.01F, 0.02F);
        // Set initial values
        float i = PlayerPrefs.GetFloat("Stock_value", 0);
        float j = PlayerPrefs.GetFloat("Delta", 0); 
        float k = PlayerPrefs.GetFloat("Variance", 0);

        set_stock(i, j, k);
    }

    void Update()
    {
        
    }

    // Set stock numerical value now
    public void set_stock(float set_value, float set_delta, float set_variance){

        // Check value is available
        if(set_value < 0){
            Debug.Log(String.Format("stock value can not be negative."));
            set_value = 0;
        } 
        else if(set_delta < min_delta || set_delta > max_delta) {
            Debug.Log(String.Format("delta value must be between " + min_delta + " and " + max_delta + ", your variance is " + set_delta));
            return;
        } 
        else if(set_variance < 0 || set_variance > max_variance){
            Debug.Log(String.Format("variance value must be between 0 and " + max_delta + ", your variance is " + set_variance));
            return;
        } 

        // Format output and update values
        string[] strings = new string[]{
            "Stock_value changed: " + stock_value + " -> " + set_value,
            "Delta changed: " + delta + " -> " + set_delta,
            "Variance changed: " + variance + " -> " + set_variance
        };
        stock_value = set_value;
        delta = set_delta;
        variance = set_variance;

        string str = String.Join("\n", strings);
        Debug.Log(str);
    }

    // Set initial stock values when game begin, but not change game's stock numerical now
    public void initial_stock (float i, float j, float k){

        PlayerPrefs.SetFloat("Stock_value", i); 
        PlayerPrefs.SetFloat("Delta", j); 
        PlayerPrefs.SetFloat("Variance", k);
    }

    // Calculate the next stock value
    public float next_stock_value(){
        float max = stock_value + delta + variance;
        float min = stock_value + delta - variance;

        System.Random rand = new System.Random();
        double range = (double)max - (double)min;
        //for (int i = 0; i < 10; i++) {
        double sample = rand.NextDouble();
        double scaled = (sample * range) + min;
        float f = (float)scaled;
        //Console.WriteLine(f);

        return f;
    }

    // update the variables accordingly
    public void next_stock_turn(float direct_change = 0, float delta_change = 0, float variance_change = 0){
        float tmp_value = stock_value + direct_change;
        float tmp_delta = delta + delta_change;
        float tmp_variance = variance + variance_change;
        set_stock(tmp_value, tmp_delta, tmp_variance);
    }

}

