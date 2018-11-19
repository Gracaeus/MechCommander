using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
	public float playerStartHealth=100f;
	public float playerHealth;
	public Rigidbody rb;
	// Use this for initialization
	private void OnEnable()
	{
		playerHealth = playerStartHealth;
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		gameObject.SetActive(true);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		
		if (playerHealth <= 0)
		{
			rb.isKinematic = false;
		}
	}
	public void Hit(float damage)
	{
		playerHealth -= damage;
		if (playerHealth <= 1)
		{
			//rb.isKinematic = false;
			gameObject.SetActive(false);
		}
	}
	public void SetPosition()
	{
		
	}
}
