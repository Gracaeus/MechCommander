using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class health : MonoBehaviour
{
	public float playerStartHealth=100f;
	public float playerHealth;

    public Slider healthBar;
    public GameObject healthBarUI;

	//public Rigidbody rb;
    //public turnManager postion;
    //public Transform mySpawn;
    
	// Use this for initialization
	void OnEnable()
	{
		playerHealth = playerStartHealth;
        gameObject.SetActive(true);
        //healthBar.value = playerHealth;
        //SetPosition();    
        //rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		
		//if (playerHealth <= 0)
		//{
		//	rb.isKinematic = false;
		//}
	}
	void Hit(float damage)
	{
		playerHealth -= damage;
        //SetHealthBar();
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Heal( float health)
    {
        playerHealth += health;
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

    void SetHealthBar()
    {
        healthBar.value = playerHealth;
    }
}
