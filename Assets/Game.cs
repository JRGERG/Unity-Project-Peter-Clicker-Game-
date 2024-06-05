using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    // Clicker
    public Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    // Shop
    public int shop1Price;
    public Text shop1Text;

    public int shop2Price;
    public Text shop2Text;

    // Amount
    public Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public Text amount2Text;
    public int amount2;
    public float amount2Profit;


    //upgrade
    public int upgradePrice;
    public Text upgradeText;

    void Start() {

        // Clicker
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0F;

        //Set all default variables before load
        shop1Price = 25;
        shop2Price = 125;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 5;

        //reset line
        PlayerPrefs.DeleteAll();

        //load
        currentScore = PlayerPrefs.GetFloat("currentScore", 0);
        hitPower = PlayerPrefs.GetFloat("hitPower", 1);
        x = PlayerPrefs.GetFloat("x", 0);

        shop1Price = PlayerPrefs.GetInt("shop1Price", 25);
        shop2Price = PlayerPrefs.GetInt("shop2Price", 125);
        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetFloat("amount1Profit", 1);
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetFloat("amount2Profit", 5);
        upgradePrice = PlayerPrefs.GetInt("upgradePrice", 50);
    }

    // Update is called once per frame
    void Update() {

        // Clicker
        scoreText.text = ((int)currentScore) + " $";
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore = currentScore + scoreIncreasedPerSecond;

        // Shop
        shop1Text.text = "Tier 1: " + shop1Price + " $";
        shop2Text.text = "Tier 2: " + shop2Price + " $";

        // Amount
        amount1Text.text = "Tier 1: "+ amount1+" arts $: "+amount1Profit+"/s";
        amount2Text.text = "Tier 2: "+ amount2+" arts $: "+amount2Profit+"/s";

        //upgrade
        upgradeText.text = "Cost: "+upgradePrice+" $";

        //Save
        PlayerPrefs.SetFloat("currentScore", currentScore);
        PlayerPrefs.SetFloat("hitPower", hitPower);
        PlayerPrefs.SetFloat("x", x);

        PlayerPrefs.SetInt("shop1Price", shop1Price);
        PlayerPrefs.SetInt("shop2Price", shop2Price);
        PlayerPrefs.SetInt("amount1", amount1);
        PlayerPrefs.SetFloat("amount1Profit", amount1Profit);
        PlayerPrefs.SetInt("amount2", amount2);
        PlayerPrefs.SetFloat("amount2Profit", amount2Profit);
        PlayerPrefs.SetInt("upgradePrice", upgradePrice);
    }

    // Hit
    public void Hit() {
        currentScore += hitPower;
    }

    //shop
    public void Shop1()
    {
        if(currentScore>=shop1Price)
        {
            currentScore -= shop1Price;
            amount1 +=1;
            amount1Profit +=1;
            x +=1;
            shop1Price +=25;
        }
    }

    public void Shop2()
    {
        if(currentScore>=shop2Price)
        {
            currentScore -= shop2Price;
            amount2 +=1;
            amount2Profit +=5;
            x +=5;
            shop2Price +=125;
        }
    }

    //upgrade 
    public void Upgrade()
    {
        if(currentScore>=upgradePrice)
        {
            currentScore -=upgradePrice;
            hitPower *= 2;
            upgradePrice *=3;
        }
    }
}