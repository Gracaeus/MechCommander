using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour {
	private int turnNo;
	private bool choiceOneMade = false;
	private bool choiceTwoMade = false;
	private string moveOne;
	private string moveTwo;


    //public GameObject bulletPrefab;
    //public Transform bulletSpawnOne;
    //public Transform bulletSpawnTwo;
    //public float fireTime;

    public GameObject shieldPrefab;
	public Transform shieldSpawnOne;
	public Transform shieldSpawnTwo;

	public GameObject healPrefab;
	public Transform healSpawnOne;
	public Transform healSpawnTwo;

    public GameObject playerOneAsset;
    public GameObject playerTwoAsset;
    public fireBullet playerOneAttack;
    public fireBullet playerTwoAttack;

	// Use this for initialization
	void Start () {
		turnNo = 0;
		choiceOneMade = false;
		choiceTwoMade = false;

        playerOneAttack = playerOneAsset.GetComponent<fireBullet>();
        playerTwoAttack = playerTwoAsset.GetComponent<fireBullet>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerOne();
        PlayerTwo();
		if (choiceOneMade == true && choiceTwoMade == true)
		{
			Play(moveOne,moveTwo);
		}
	}

    public void PlayerOne()
    {
        if (Input.GetButtonDown("Attack1"))
        {
            moveTwo = "attack";
            choiceOneMade = true;
        }
        if (Input.GetButtonDown("Shield1"))
        {
            moveTwo = "shield";
            choiceOneMade = true;
        }
        if (Input.GetButtonDown("Heal1"))
        {
            moveTwo = "heal";
            choiceOneMade = true;
        }
    }

	private void PlayerTwo()
	{
        if (Input.GetButtonDown("Attack2"))
        {
            moveTwo = "attack";
            choiceTwoMade = true;
        }
        if (Input.GetButtonDown("Shield2"))
        {
            moveTwo = "shield";
            choiceTwoMade = true;
        }
        if (Input.GetButtonDown("Heal2"))
        {
            moveTwo = "heal";
            choiceTwoMade = true;
        }
        
	}

	private void Play(string choice, string secondChoice)
	{
        //Player One move
        {
            if (choice == "attack")
            {
                playerOneAttack.Fire();
                //Instantiate(bulletPrefab, bulletSpawnOne.position, bulletSpawnOne.rotation);
                //Invoke("SetFiring", fireTime);
            }
            else if (choice == "shield")
            {
                Instantiate(shieldPrefab, shieldSpawnOne.position, shieldSpawnOne.rotation);
            }
            else if (choice == "heal")
            {
                Instantiate(healPrefab, healSpawnOne.position, healSpawnOne.rotation);
            }
        }
        // Player Two move
        {
            if (secondChoice == "attack")
            {
                playerTwoAttack.Fire();
                //Instantiate(bulletPrefab, bulletSpawnTwo.position, bulletSpawnTwo.rotation);
                //Invoke("SetFiring", fireTime);
            }
            else if (secondChoice == "shield")
            {
                Instantiate(shieldPrefab, shieldSpawnTwo.position, shieldSpawnTwo.rotation);
            }
            else if (secondChoice == "heal")
            {
                Instantiate(healPrefab, healSpawnTwo.position, healSpawnTwo.rotation);
            }
        }

		EndTurn();
	}

	private void EndTurn()
	{
		choiceOneMade = false;
		choiceTwoMade = false;

	}
		
	}

