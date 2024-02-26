using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public enum items {
      RHIZO,    // rhoizobium
      BIOPEST,  // bio pesticides
      FERT,     // fertilzier 
      SEED     // seeds
    }

    public enum status {
      CON,  // conventional
      SUS,  // sustainable
      ORG  // organic
    }

    public float money = 5000;
    // public Text moneyTextDisplay;
    public int rhizobium = 0;
    public int pesticides = 0;
    public int fert = 0;
    public int seeds = 0;

    // use a 2D array instead of individual variables to also keep track for the statuses?

    /* 2D array for the inventory, first index is the type of item (seed, fertilizer, etc)
     * and the second index is the status (conventional, sustainable, organic). I plan on 
     * using ENUMs for both of these so we don't have to memorize which number corresponds to
     * which item or status
     */
    public int[][] inventory;

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

      /* Do I even need this? Just initializing the inventory array, but it doesn't
       * seem like the old group ever fully initialized the menu...[] arrays in TurnManager
       */
      // for (int i = 0; i < 4; i++) {
      //   for (int j = 0; j < 3; j++) {
      //     inventory[i][j] = 0;
      //   }
      // }
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

    /* Adds and subtracts from the inventory -- positive amount to add, negative to subtract
     * type and status parameters so that we only need one function for every button/action
     * that interacts with the inventory. 
     */
    public bool changeInventory(int type, int status, int amount) {
      /* If negative amount, also need to have enough in inventory, or if positive amount,
       * then just change inventory as needed and return true, else return false
       */
      if ((amount < 0 && inventory[type][status] > 0) || amount > 0) {
        inventory[type][status] += amount;
        return true;
      } else {
        return false;
      }
    }
}
