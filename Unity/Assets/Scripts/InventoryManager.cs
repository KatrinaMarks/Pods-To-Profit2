using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public float money = 5000;
    // public Text moneyTextDisplay;
    public int rhizobium = 0;
    public int pesticides = 0;
    public int fert = 0;
    public int seeds = 0;

    public TMP_Text moneyText;
    public TMP_Text shopMoneyText;
    public TMP_Text rText;
    public TMP_Text pText;
    public TMP_Text fText;

    public bool ownTractor = false;
    public bool brokenTractor = false;
    // Start is called before the first frame update
    void Start()
    {
      moneyText.text = "$" + money;
      shopMoneyText.text = "$" + money;
      // moneyTextDisplay.text = "$" + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      rText.text = "Rhizobium: " + rhizobium;
      pText.text = "BioPesticides: " + pesticides;
      fText.text = "Fertilizer: " + fert;
    }

    /* Adds to money. Pass in negative amount to subtract */
    public bool changeMoney(float amt)
    {
      /* I believe this if statement makes sure that if a negative amount is passed in,
       * therein subtracting from the total money, then the transaction is only allowed 
       * if and only if the amount to be subtracted is not greater than the current balance.
       * With this returning false, it may already exist (I just haven't looked for it yet),
       * but we should double check that there is some sore of feedback if this if statement is
       * false -- i.e. "Not enough money" warning
       */
      if(amt >= 0 || money >= Math.Abs(amt))
      {
        money += amt;
        moneyText.text = "$" + money;
        shopMoneyText.text = "$" + money;
        return true;
      }
      return false;
    }
}
