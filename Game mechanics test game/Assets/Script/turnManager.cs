using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour {
	private int turnNo;
	private bool choiceOneMade = false;
	private bool choiceTwoMade = false;
	private string moveOne;
	private string moveTwo;


	public GameObject bulletPrefab;
	public Transform bulletSpawnOne;
	public Transform bulletSpawnTwo;
	public float fireTime;

	public GameObject shieldPrefab;
	public Transform shieldSpawnOne;
	public Transform shieldSpawnTwo;

	public GameObject healPrefab;
	public Transform healSpawnOne;
	public Transform healSpawnTwo;

	// Use this for initialization
	void Start () {
		turnNo = 0;
		choiceOneMade = false;
		choiceTwoMade = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (choiceOneMade == true && choiceTwoMade == true)
		{
			Play(moveOne,moveTwo);
		}
	}

	public void playerOne(string choice)
	{
		moveOne = choice;
		choiceOneMade = true;
	}

	private void playerTwo(string choice)
	{
		moveTwo = choice;
		choiceTwoMade = true;
	}

	private void Play(string choice, string secondChoice)
	{
		//Player One move
		if (choice == "attack")
		{
			Instantiate(bulletPrefab, bulletSpawnOne.position, bulletSpawnOne.rotation);

			Invoke("SetFiring", fireTime);
		}
		else if (choice == "shield")
		{
			Instantiate(shieldPrefab, shieldSpawnOne.position, shieldSpawnOne.rotation);
		}
		else if (choice == "heal")
		{
			Instantiate(healPrefab, healSpawnOne.position, healSpawnOne.rotation);
		}
		// Player Two move
		if (secondChoice == "attack")
		{
			Instantiate(bulletPrefab, bulletSpawnTwo.position, bulletSpawnTwo.rotation);

			Invoke("SetFiring", fireTime);
		}
		else if (secondChoice == "shield")
		{
			Instantiate(shieldPrefab, shieldSpawnTwo.position, shieldSpawnTwo.rotation);
		}
		else if (secondChoice == "heal")
		{
			Instantiate(healPrefab, healSpawnTwo.position, healSpawnTwo.rotation);
		}

		EndTurn();
	}

	private void EndTurn()
	{
		choiceOneMade = false;
		choiceTwoMade = false;

	}
		
	}

