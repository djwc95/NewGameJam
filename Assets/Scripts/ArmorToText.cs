using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorToText : MonoBehaviour
{
    public Text armorText;

    public PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        armorText.text = playerHealth.armor.ToString() + " / " + playerHealth.maxArmor.ToString(); //update our armor counter in UI canvas
        Debug.Log("armorCalled");
    }
}
