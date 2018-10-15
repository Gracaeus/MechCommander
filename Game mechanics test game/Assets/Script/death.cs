using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {
    public GameObject shield;
    public shieldBehaviour shieldHealth;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("bullet"))
        {
            if (shieldHealth.shieldHP >= 1)
            {
                shield.SetActive(true);
            }
            else
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
           
        }
    }
}
