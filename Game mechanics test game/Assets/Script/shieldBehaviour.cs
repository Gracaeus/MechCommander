using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBehaviour : MonoBehaviour {

    public float shieldHP;

	public float destroyTime = 2f;
	Animator anime;

	void Start()
	{
		shieldHP = 100F;
		Invoke("Die", destroyTime);
	}
	void Die()
	{
		Destroy(gameObject);
	}


    public void takeDamage(float damage)
    {
        shieldHP -= damage;


        if (shieldHP <= 0)
        {
            Destroy(gameObject);
        }
    }
	
}
