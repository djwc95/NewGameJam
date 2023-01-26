using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int healValue = 2;
    public GameObject healthParticles;

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeHealth(healValue);
            Instantiate(healthParticles, other.transform);
            Destroy(gameObject);
        }
    }
}
