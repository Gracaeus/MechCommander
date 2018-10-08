using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 5.0f;
    public float destroyTime = 0.07f;

    
    void Start()
    {
        Invoke("Die", destroyTime);

    }
    void Die()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}

