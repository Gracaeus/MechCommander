using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 5.0f;
    public float destroyTime = 0.07f;
    public float damage = 10f;


    private shieldBehaviour shield;
    public GameObject shieldAsset;

    
    void Start()
    {
        Invoke("Die", destroyTime);

        shield = shieldAsset.GetComponent<shieldBehaviour>();

    }
    void Die()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("shield"))
        {
            shield.takeDamage(damage);
        }
    }
}


