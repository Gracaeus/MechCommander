using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class healing : MonoBehaviour {

	public GameObject healingPrefab;
	public Transform healingSpawn;
	public float destroyTime = 1f;

<<<<<<< HEAD

   
=======
>>>>>>> parent of 9c578a9... Turn based fixed
	public void SpawnHealth()
	{
		Instantiate(healingPrefab, healingSpawn.position, healingSpawn.rotation);
		Invoke("Die", destroyTime);
	}
	void Die()
	{
		Destroy(gameObject);
	}
}
