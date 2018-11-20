using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	void Start () 
    {
        //Sets the choice made to false so the players can pick their choices
        choiceOneMade = false;
        choiceTwoMade = false;

        //Allows the combat manager to access the neccessary scripts for the first player
        playerOneShield = playerOneAsset.GetComponent<shieldGenerator>();
        playerOneAttack = playerOneAsset.GetComponent<fireBullet>();
        playerOneHeal = playerOneAsset.GetComponent<healing>();

        //Allows the combat manager to access the neccessary scripts for the second player
        playerTwoShield = playerTwoAsset.GetComponent<shieldGenerator>();
        playerTwoAttack = playerTwoAsset.GetComponent<fireBullet>();
        playerTwoHeal = playerTwoAsset.GetComponent<healing>();

    }

    // Runs the methods that allow the players to pick
    void FixedUpdate () 
    {
        PlayerOne();
        PlayerTwo();

        if (choiceOneMade == true && choiceTwoMade == true)
        {
            TurnPlay(moveOne, moveTwo);
        }
	}

    //Allows player one to pick their move
    private void PlayerOne()
    {
        if (Input.GetButtonDown("Attack1"))
        {
            moveOne = "attack";
            choiceOneMade = true;
        }
        else if (Input.GetButtonDown("Shield1"))
        {
            moveOne = "shield";
            choiceOneMade = true;
        }
        else if (Input.GetButtonDown("Heal1"))
        {
            moveOne = "heal";
            choiceOneMade = true;
        }
    }

    //Allows player two to pick their move
    private void PlayerTwo()
    {
        if (Input.GetButtonDown("Attack2"))
        {
            moveTwo = "attack";
            choiceTwoMade = true;
        }
        else if (Input.GetButtonDown("Shield2"))
        {
            moveTwo = "shield";
            choiceTwoMade = true;
        }
        else if (Input.GetButtonDown("Heal2"))
        {
            moveTwo = "heal";
            choiceTwoMade = true;
        }
    }

    //Converts the button pressed into an action
    private void TurnPlay(string choice, string choiceTwo)
    {
        switch (choice)
        {
            case "attack":
                playerOneAttack.Fire();
                break;
            case "shield":
                playerOneShield.SpawnShield();
                break;
            case "heal":
                playerOneHeal.SpawnHealth();
                break;
        }

        switch(choiceTwo)
        {
            case "attack":
                playerTwoAttack.Fire();
                break;
            case "shield":
                playerTwoShield.SpawnShield();
                break;
            case "heal":
                playerTwoHeal.SpawnHealth();
                break;
        }

        EndTurn();
    }

    private void EndTurn()
    {
        choiceOneMade = false;
        choiceTwoMade = false;
    }
}
