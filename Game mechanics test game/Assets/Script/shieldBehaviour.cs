using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBehaviour : MonoBehaviour {

    public float shieldHP = 100f;
    public GameObject shield;

    public void takeDamage(float damage)
    {
        shieldHP -= damage;


        if (shieldHP <= 0)
        {
            shield.SetActive(false);
        }
    }
	
}
