using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDmgEnemy : MonoBehaviour
{
    bool canAttack;

    public GameObject player;

    public SplashAttack splashAttack;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            splashAttack.StartSplash();
            StartCoroutine(AtkCooldown());
        }
    }

    public IEnumerator AtkCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(15f);
        canAttack = true;
    }
}
