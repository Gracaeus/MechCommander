using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
	public float playerStartHealth=100f;
	public float playerHealth;
	//public Rigidbody rb;
 //   public turnManager postion;
 //   public Transform mySpawn;
    
	// Use this for initialization
	void OnEnable()
	{
		playerHealth = playerStartHealth;
		//rb = GetComponent<Rigidbody>();
		//rb.isKinematic = true;
		gameObject.SetActive(true);
        //SetPosition();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		
		//if (playerHealth <= 0)
		//{
		//	rb.isKinematic = false;
		//}
	}
	public void Hit(float damage)
	{
		playerHealth -= damage;
		if (playerHealth <= 1)
		{
			//rb.isKinematic = false;
			gameObject.SetActive(false);
            GetComponent<Rigidbody>().isKinematic = false;
            //Invoke("Die", destroyTime);
		}
	}

    void Die()
    {
        Destroy(gameObject);
    }
	//public void SetPosition()
	//{
	//	if(mySpawn.tag == "playerOneSpawn")
 //       {
 //           postion.playerOneAsset = gameObject;
 //       }
 //       if (mySpawn.tag == "playerTwoSpawn")
 //       {
 //           postion.playerTwoAsset = gameObject;
 //       }

 //   }
}
