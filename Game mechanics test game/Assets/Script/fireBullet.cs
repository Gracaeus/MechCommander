using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.1f;
    private bool isFiring = false;

	void Start()
	{

	}
    public void Fire(float damage)
    {
        isFiring = true;
        bulletPrefab.SendMessage("SetDamage", damage);
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        Invoke("SetFiring", fireTime);
    }
	
    void SetFiring()
    {
        isFiring = false;
    }

}
