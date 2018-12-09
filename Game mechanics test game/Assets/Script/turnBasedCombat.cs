using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnBasedCombat : MonoBehaviour {
    private bool choiceOneMade;
    private bool choiceTwoMade;

    private string moveOne;
    private string moveTwo;

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

    private int turnCounter=0;
    public Text textCounter;

    private bool newTurn = true;


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
    }

    // Runs the methods that allow the players to pick
    void Update () 
    {
        //f (choiceOneMade == false && choiceTwoMade == false)
        //{
           // TurnSetup();
       // }
        //PlayersChoices();

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
            TurnPlay(moveOne, moveTwo);
        }
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
    }

    //Converts the button pressed into an action
    private void TurnPlay(string choice, string choiceTwo)
    {
        turnCounter += 1;
        //PlayerOne();
        //PlayerTwo();
        switch (choice)
        {
            case "attack":
                playerOneAttack.Fire();
                moveOne = "";
                Debug.Log("Move Reset");
                break;
            case "shield":
                playerOneShield.SpawnShield();
                moveOne = "";
                Debug.Log("Move Reset");
                break;
            case "heal":
                playerOneHeal.SpawnHealth();
                moveOne = "";
                Debug.Log("Move Reset");
                break;
        }

        switch(choiceTwo)
        {
            case "attack":
                playerTwoAttack.Fire();
                moveTwo = "";
                Debug.Log("Move Reset");
                break;
            case "shield":
                playerTwoShield.SpawnShield();
                moveTwo = "";
                Debug.Log("Move Reset");
                break;
            case "heal":
                playerTwoHeal.SpawnHealth();
                moveTwo = "";
                Debug.Log("Move Reset");
                break;
        }
       
        EndTurn();
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
}
