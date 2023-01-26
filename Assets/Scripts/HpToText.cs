using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpToText : MonoBehaviour
{
    public Text healthText;

    public PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealth.currentHealth.ToString() + " / " + playerHealth.maxHealth.ToString(); //update our hp counter in UI canvas
    }
}
