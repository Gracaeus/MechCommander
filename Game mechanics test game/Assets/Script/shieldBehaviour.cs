using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBehaviour : MonoBehaviour {

    public int shieldHP = 100;

	
	private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("bullet"))
        {
            shieldHP -= 10;
            System.Console.WriteLine(shieldHP);
            if (shieldHP<=0)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
