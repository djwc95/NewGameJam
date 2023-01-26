using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
