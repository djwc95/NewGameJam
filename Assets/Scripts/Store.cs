using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerAttack playerAttack;
    public PlayerBehaviour playerBehaviour;

    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void TakeDmg(int amount)
    {
        player.gameObject.GetComponent<PlayerHealth>().TakeDmg(amount);
    }

    public void ArmorBuff(int amount)
    {
        player.gameObject.GetComponent<PlayerHealth>().ArmorBuff(amount);
    }

    public void DmgBuff(int amount)
    {
        player.gameObject.GetComponent<PlayerAttack>().DmgBuff(amount);
    }

    public void CritBuff(int amount)
    {
        player.gameObject.GetComponent<PlayerAttack>().CritBuff(amount);
    }

    public void DashBuff(float amount)
    {
        player.gameObject.GetComponent<PlayerBehaviour>().DashBuff(amount);
    }

    public void SpeedBuff(int amount)
    {
        player.gameObject.GetComponent<PlayerBehaviour>().SpeedBuff(amount);
    }
}
