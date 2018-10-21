using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healing : MonoBehaviour {

	public GameObject healingPrefab;
	public Transform healingSpawn;



	public void SpawnHealth()
	{
		Instantiate(healingPrefab, healingSpawn.position, healingSpawn.rotation);
	}
}
