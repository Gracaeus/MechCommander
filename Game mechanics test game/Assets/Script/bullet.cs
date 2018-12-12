﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet : MonoBehaviour {
    public float speed = 5.0f;
    public float destroyTime = 0.07f;
    public float damage=10f;

	//private health player;
 //   private shieldBehaviour shield;
 //   public GameObject shieldAsset;
	//public GameObject playerAsset;

    
    void Start()
    {
        Invoke("Die", destroyTime);
        //damage = Random.RandomRange(5f, 10f);
		//player = playerAsset.GetComponent<health>();
  //      shield = shieldAsset.GetComponent<shieldBehaviour>();

    }
    void Die()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.SendMessage("Hit",damage);
            Debug.Log("Damaging Player:" + damage);
            Die();
        }
        else if(collision.gameObject.CompareTag("shield"))
        {
            collision.SendMessage("takeDamage", damage);
            Debug.Log("Damaging Shield:" + damage);

        }
    }

    private void HealthUpdate (float shieldHealth)
    {
        damage -= shieldHealth;
    }

    void SetDamage(float amount)
    {
        damage = amount;
    }

    //private void OnTrigger(Collider collision)
    //{
    //	if (collision.gameObject.CompareTag("shield"))
    //	{
    //		collision.SendMessage("Hit", damage);
    //	}
    //}
}


