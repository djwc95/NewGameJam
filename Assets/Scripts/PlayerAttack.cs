using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    //dmg variables
    public int damage;
    float timeUntilMelee;
    public int dmgBuff;
    //audio
    public AudioClip swing;
    AudioSource audioSource;
    public GameObject sparks;
    //critical hits
    int critDmg;
    public float critChance;
    int randValue;

    public AiChase aiChase;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        critChance = 7f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.E)) //do nothing while blocking
        {
            return;
        }
        if (timeUntilMelee <= 0f) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(swing, 0.5f);
                anim.SetTrigger("Attack"); //start the sword swinging animation
                timeUntilMelee = meleeSpeed; //how long until we can atk again?
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime; 
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(sparks, other.transform);
            randValue = Random.Range(0, 100);
            if (randValue < critChance) // roll for a crit
            {
                critDmg = (damage * 2);
                other.gameObject.GetComponent<EnemyHealth>().TakeDmg(critDmg); //we got it
                Debug.Log("Crit Hit");
            }
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDmg(damage); // regular atk dmg
                Debug.Log("Normal Hit");
            }
            other.gameObject.GetComponent<AiChase>().Knockback();
        }
        else if (other.tag == "DashEnemy")
        {
            randValue = Random.Range(0, 100);
            if (randValue < critChance) // roll for a crit
            {
                critDmg = (damage * 2);
                other.gameObject.GetComponent<EnemyHealth>().TakeDmg(critDmg); //we got it
                Debug.Log("Crit Hit");
            }
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDmg(damage); // regular atk dmg
                Debug.Log("Normal Hit");
            }
            other.gameObject.GetComponent<AiDash>().Knockback();
        }
    }

    //========================== BUFFS WE CAN BUY IN SHOP ==============================
    public void DmgBuff(int dmgBuff)
    {
        damage += dmgBuff;
    }

    public void CritBuff(int critBuff)
    {
        critChance += critBuff;
    }
}
