using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    
    public enum items {
      PEST,     // bio pesticides
      RHIZ,     // rhoizobium
      FERT,     // fertilzier 
      SEED      // seeds
    }

    public enum status {
      CON,  // conventional
      SUS,  // sustainable
      ORG,  // organic
      SUM   // sum 
    }

    public float money = 5000;
    // public Text moneyTextDisplay;
    public int rhizobium = 0;
    public int pesticides = 0;
    public int fert = 0;
    public int seeds = 0;

    // use a 2D array instead of individual variables to also keep track for the statuses?

    /* 2D array for the inventory, first index (row) is the type of item (seed, fertilizer, etc)
     * and the second index (column) is the status (conventional, sustainable, organic). The fourth
     * column of each row is for the sliders in the toolbar, it is just how many types to display. 
     * I plan on using ENUMs for both of these so we don't have to memorize which number corresponds 
     * to which item or status, they're declared above but I haven't used them yet
     */
    public int[][] inventory = new int[4][];

    public TMP_Text moneyText;
    public TMP_Text shopMoneyText;
    public TMP_Text rText;
    public TMP_Text pText;
    public TMP_Text fText;

    public bool ownTractor = false;
    public bool brokenTractor = false;

    [Header("Slider Texts")]
    public TMP_Text fertSlot1Text; 
    public TMP_Text fertSlot2Text; 
    public TMP_Text fertSlot3Text; 

    // [Header("Shop Buttons")]
    // public Button buySeedConButton;
    // public Button buySeedSusButton;
    // public Button buySeedOrgButton;
    // public Button buyFertConButton;
    // public Button buyFertSusButton;
    // public Button buyFertOrgButton;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money;
        shopMoneyText.text = "$" + money;
        // moneyTextDisplay.text = "$" + money.ToString();

        /* Do I even need this? Just initializing the inventory array, but it doesn't
         * seem like the old group ever fully initialized the menu...[] arrays in TurnManager
         */
        /*                         con     sus     org    num                         */
        inventory[0] = new int[4] {0,       0,      0,      0};     // bio pest
        inventory[1] = new int[4] {0,       0,      0,      0};     // rhizo
        inventory[2] = new int[4] {0,       0,      0,      0};     // fert
        inventory[3] = new int[4] {0,       0,      0,      0};     // seeds
    }

    // Update is called once per frame
    void Update()
    {
        // rText.text = "Rhizobium: " + rhizobium;
        // pText.text = "BioPesticides: " + pesticides;
        // fText.text = "Fertilizer: " + fert;

        if (inventory[2][3] > 0) {
            int i = 0;
            // if only one slot showing, find which type and display it's number
            if (inventory[2][3] <= 1) {
                while (inventory[2][i] == 0) i++;
                fertSlot1Text.text = "x" + inventory[2][i];
            // else if only two showing, find and display the two > 0
            } else if (inventory[2][3] == 2) {
                while (inventory[2][i] == 0) i++;
                fertSlot1Text.text = "x" + inventory[2][i++];
                while (inventory[2][i] == 0) i++;
                fertSlot2Text.text = "x" + inventory[2][i];
            // else all three showing so display accordingly
            } else {
                fertSlot1Text.text = "x" + inventory[2][0];
                fertSlot2Text.text = "x" + inventory[2][1];
                fertSlot3Text.text = "x" + inventory[2][2];
            }
        }
        // idk why the enums don't work, I'll figure that out later
        // fertSlot1Text.text = "x" + inventory[items.FERT][status.CON];
        // fertSlot2Text.text = "x" + inventory[items.FERT][status.SUS];
        // fertSlot3Text.text = "x" + inventory[items.FERT][status.ORG];

        // fertSlot1Text.text = "x" + inventory[2][0];
        // fertSlot2Text.text = "x" + inventory[2][1];
        // fertSlot3Text.text = "x" + inventory[2][2];
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
     *
     * The parameter is a string because only functions with one parameter show up in the Unity
     * editor... for whatever reason... and I found using one string as a sequence of integers
     * to be easier and more efficient than programming onClick for each button.
     */
    public void changeInventory(string typeStatusAmount) {
        int type = typeStatusAmount[0] - '0';
        int status = typeStatusAmount[1] - '0';
        int amount = typeStatusAmount[2] - '0';
        // string output = string.Format("Integers: {0}, {1}, {2}", type, status, amount);
        // Debug.Log(output);
        /* If negative amount, also need to have enough in inventory, or if positive amount,
         * then just change inventory as needed and return true, else return false
         */
        if ((amount < 0 && inventory[type][status] > 0) || amount > 0) {
            if (inventory[type][status] == 0) inventory[type][3]++;
            inventory[type][status] += amount;
            // return true; 
        } else {
            // inupt some form of error message that there is not enough money or items left
            // return false;
        }
    }

    public void testFunc(string test) {
        
    }
}
