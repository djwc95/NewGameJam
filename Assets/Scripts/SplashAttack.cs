using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAttack : MonoBehaviour
{
    public GameObject warningZone;
    public GameObject player;

    public SplashDmgEnemy splashDmgEnemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartSplash()
    {
        StartCoroutine(SplashAtk());
    }

    public IEnumerator SplashAtk()
    {
        var thisZone = Instantiate(warningZone, player.transform.localPosition, player.transform.rotation);
        this.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(5f);
        this.GetComponent<Collider2D>().enabled = true;
        Destroy(thisZone, 5f);
    }
}
