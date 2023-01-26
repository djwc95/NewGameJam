using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject floatingDmg;

    public SpriteRenderer rend;
    public AudioClip clink;
    AudioSource audioSource;

    public float spawnChance = 20f;
    public GameObject healthDrop;
    public GameObject smokeParticles;
    int randValue;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<SpriteRenderer>();
    }

    public void TakeDmg(int amount)
    {
        currentHealth -= amount; // take dmg
        StartCoroutine(FlashRed()); //player feedback
        audioSource.PlayOneShot(clink, 0.5f);//player feedback

        GameObject dmgGiven = Instantiate(floatingDmg, transform.position, Quaternion.identity) as GameObject; // spawn floating dmg numbers
        dmgGiven.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString(); // reflects our current dmg to the floating dmg num
        if (currentHealth <= 0)
        {
            audioSource.PlayOneShot(clink, 0.5f);
            StartCoroutine(Death());
        }
    }

    public IEnumerator FlashRed()
    {
        rend.color = Color.red;
        Physics2D.IgnoreLayerCollision(6, 8, true);
        yield return new WaitForSeconds(.25f);
        rend.color = Color.white;
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(.35f);
        randValue = Random.Range(0, 100);
        if (spawnChance > randValue)
        {
            Instantiate(healthDrop, transform.position, transform.rotation);
        }
        Instantiate(smokeParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
