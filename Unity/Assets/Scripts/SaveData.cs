using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class SaveData : MonoBehaviour
{
    public Game_State basic_data = new Game_State();

    public void SaveJson(){
        Debug.Log("Save Data");
        string json_file = JsonUtility.ToJson(basic_data);
        string path = Application.persistentDataPath + "/PodstoProfit.josn";

        System.IO.File.WriteAllText(path, json_file);
        Debug.Log("Save Data");
        Debug.Log(path);
    }

    public void LoadJson(){
        string path = Application.persistentDataPath + "/PodstoProfit.josn";
        string json_file = System.IO.File.ReadAllText(path);

        basic_data = JsonUtility.FromJson<Game_State>(json_file);

        Debug.Log("Load Data");
        Debug.Log(path);
    }
}
 [System.Serializable]
public class Game_State{
    public int cash;
    public int rhizo;
    public int pest;
    public bool tractor;
    public int temperature;
    public string Turns;
    /* Need to known structure of perks and tool*/
    // public [] string perks;
    // public [] string tool;
}