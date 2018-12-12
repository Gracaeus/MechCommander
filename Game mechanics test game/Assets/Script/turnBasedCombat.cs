using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnBasedCombat : MonoBehaviour {

    //These are used to control the flow of the game 
    private bool choiceOneMade;
    private bool choiceTwoMade;
    private string moveOne;
    private string moveTwo;

    //These are the assets and the scripts that need to be accessed to do work
    public GameObject playerOneAsset;
    public GameObject playerTwoAsset;
    private shieldGenerator playerOneShield;
    private shieldGenerator playerTwoShield;
    private fireBullet playerOneAttack;
    private fireBullet playerTwoAttack;
    private healing playerOneHeal;
    private healing playerTwoHeal;
    private health playerOneHealth;
    private health playerTwoHealth;
    public Slider playerOneHealthBar;
    public Slider playerTwoHealthBar;

    //Sets what turn the game is on
    private int turnCounter=0;
    public Text textCounter;
    private bool newTurn = true;

    //This sets the camera changes 
    public GameObject PlayerOneCamera;
    public GameObject PlayerTwoCamera;

    //These are needed for when the player is setting the power level
    private bool playerOnePowerSet;
    private bool playerTwoPowerSet;
    public Slider playerOnePowerBar;
    public Slider playerTwoPowerBar;
    private float playerOnePowerValue;
    private float playerTwoPowerValue;

    public GameObject hintPanel;
    public GameObject chargeHint;
    public GameObject moveHint;
    public GameObject continueHint;

	void Start () 
    {
        //Sets the choice made to false so the players can pick their choices
        choiceOneMade = false;
        choiceTwoMade = false;

        //Allows the combat manager to access the neccessary scripts for the first player
        playerOneShield = playerOneAsset.GetComponent<shieldGenerator>();
        playerOneAttack = playerOneAsset.GetComponent<fireBullet>();
        playerOneHeal = playerOneAsset.GetComponent<healing>();
        playerOneHealth = playerOneAsset.GetComponent<health>();

        //Allows the combat manager to access the neccessary scripts for the second player
        playerTwoShield = playerTwoAsset.GetComponent<shieldGenerator>();
        playerTwoAttack = playerTwoAsset.GetComponent<fireBullet>();
        playerTwoHeal = playerTwoAsset.GetComponent<healing>();
        playerTwoHealth = playerTwoAsset.GetComponent<health>();
        moveOne = "";
        moveTwo = "";

        playerOnePowerSet = false;
        playerTwoPowerSet = false;
        playerOnePowerValue = 1f;
        playerTwoPowerValue = 1f;

        hintPanel.SetActive(true);
        chargeHint.SetActive(false);
        moveHint.SetActive(false);
        continueHint.SetActive(false);
    }

    // Runs the methods that allow the players to pick
    void Update () 
    {
        //f (choiceOneMade == false && choiceTwoMade == false)
        //{
        // TurnSetup();
        // }
        //PlayersChoices();
        chargeHint.SetActive(true);
        if (playerOnePowerSet == false)
        {
            PlayerOneSetPowerValue();
        }
        if (playerTwoPowerSet == false)
        {
            PlayerTwoSetPowerValue();
        }
        if(playerOnePowerSet == true && playerTwoPowerSet == true)
        {
            chargeHint.SetActive(false);
            moveHint.SetActive(true);
            if (choiceOneMade == false)
            {
                PlayerOne();
            }
            if (choiceTwoMade == false)
            {
                PlayerTwo();
            }
            if (choiceOneMade == true && choiceTwoMade == true)
            {
                hintPanel.SetActive(false);
                TurnPlay(moveOne, moveTwo);
            }
        }
        //if (choiceOneMade == false)
        //{
        //  PlayerOne();
        //}
        //if (choiceTwoMade == false)
        // {
        //  PlayerTwo();
        // }
        //if (choiceOneMade == true && choiceTwoMade == true)
        //{
        //  if (playerOnePowerSet==false)
        // {
        //     PlayerOneSetPowerValue();
        // }
        //  if (playerTwoPowerSet == false)
        //  {
        //      PlayerTwoSetPowerValue();
        //  }
        //  if (playerOnePowerSet == true && playerTwoPowerSet == true && Input.GetButtonUp("Play Turn"))
        //  {
        //      TurnPlay(moveOne, moveTwo);
        //  }

        // }
    }
    private void PlayersChoices()
    {
        PlayerOne();
        PlayerTwo();
    }
    //Allows player one to pick their move
    private void PlayerOne()
    {
        if (Input.GetButtonUp("Attack1")&& moveOne == "")
        {
            moveOne = "attack";
            choiceOneMade = true;
            Debug.Log("Player One Choice Made");
            

        }
        else if (Input.GetButtonUp("Shield1")&& moveOne == "")
        {
            moveOne = "shield";
            choiceOneMade = true;
            Debug.Log("Player One Choice Made");
        }
        else if (Input.GetButtonUp("Heal1")&& moveOne == "")
        {
            moveOne = "heal";
            choiceOneMade = true;
            Debug.Log("Player One Choice Made");
        }
        if (choiceOneMade == true)
        {
            PlayerOneCamera.SetActive(false);
        }
    }

    //Allows player two to pick their move
    private void PlayerTwo()
    {
        if (Input.GetButtonUp("Attack2") && moveTwo == "")
        {
            moveTwo = "attack";
            choiceTwoMade = true;
            Debug.Log("Player Two Choice Made");
        }
        else if (Input.GetButtonUp("Shield2") && moveTwo == "")
        {
            moveTwo = "shield";
            choiceTwoMade = true;
            Debug.Log("Player Two Choice Made");
        }
        else if (Input.GetButtonUp("Heal2") && moveTwo == "")
        {
            moveTwo = "heal";
            choiceTwoMade = true;
            Debug.Log("Player Two Choice Made");
        }
        if(choiceTwoMade==true)
        {
            PlayerTwoCamera.SetActive(false);
        }
    }

    //Converts the button pressed into an action
    private void TurnPlay(string choice, string choiceTwo)
    {
        //turnCounter += 1;
        //PlayerOne();
        //PlayerTwo();
        switch (choice)
        {
            case "attack":
                playerOneAttack.Fire(playerOnePowerValue);
                moveOne = "";
                Debug.Log("Move Reset");
                break;
            case "shield":
                playerOneShield.SpawnShield(playerOnePowerValue);
                moveOne = "";
                Debug.Log("Move Reset");
                break;
            case "heal":
                playerOneHeal.SpawnHealth(playerOnePowerValue);
                moveOne = "";
                Debug.Log("Move Reset");
                break;
        }

        switch (choiceTwo)
        {
            case "attack":
                playerTwoAttack.Fire(playerTwoPowerValue);
                moveTwo = "";
                Debug.Log("Move Reset");
                break;
            case "shield":
                playerTwoShield.SpawnShield(playerTwoPowerValue);
                moveTwo = "";
                Debug.Log("Move Reset");
                break;
            case "heal":
                playerTwoHeal.SpawnHealth(playerTwoPowerValue);
                moveTwo = "";
                Debug.Log("Move Reset");
                break;
        }
        hintPanel.SetActive(true);
        chargeHint.SetActive(false);
        moveHint.SetActive(false);
        continueHint.SetActive(true);
        if (Input.GetButtonUp("Play Turn"))
        {
            turnCounter += 1;
            EndTurn();
        }

    }
    
    //Debug this end turn
    private void EndTurn()
    {
        textCounter.text = turnCounter.ToString();
        choiceOneMade = false;
        choiceTwoMade = false;
        SetHealthBar();
        newTurn = true;
        Debug.Log("End Turn Called");
        PlayerOneCamera.SetActive(true);
        PlayerTwoCamera.SetActive(true);
        playerOnePowerSet = false;
        playerTwoPowerSet = false;
        playerTwoPowerValue = 0;
        playerOnePowerValue = 0;
        continueHint.SetActive(false);
    }
    private void TurnSetup()
    {
        if (choiceOneMade != false || choiceTwoMade != false)
        {
            choiceOneMade = false;
            choiceTwoMade = false;
            moveOne = "";
            moveTwo = "";
            newTurn = false;
            Debug.Log("Full Reset");

        }
    }
    private void SetHealthBar()
    {
        playerOneHealthBar.value = playerOneHealth.playerHealth;
        playerTwoHealthBar.value = playerTwoHealth.playerHealth;
    }

    private void PlayerOneSetPowerValue()
    {
        if (Input.GetButton("Set Power 1")&& !playerOnePowerSet)
        {
            playerOnePowerValue += 5f * Time.deltaTime;
            if (playerOnePowerValue > 10f)
            {
                playerOnePowerValue = 1f;
            }
            playerOnePowerBar.value = playerOnePowerValue;
        }
        if( Input.GetButtonUp("Set Power 1"))
        {
            playerOnePowerSet = true;
            playerOnePowerBar.value = playerOnePowerValue;
        }
    }
    private void PlayerTwoSetPowerValue()
    {
        if (Input.GetButton("Set Power 2") && !playerTwoPowerSet)
        {
            playerTwoPowerValue += 5f * Time.deltaTime;
            if (playerTwoPowerValue > 10f)
            {
                playerTwoPowerValue = 1f;
            }
            playerTwoPowerBar.value = playerTwoPowerValue;
        }
        if (Input.GetButtonUp("Set Power 2"))
        {
            playerTwoPowerSet = true;
            playerTwoPowerBar.value = playerTwoPowerValue;
        }
    }
}
