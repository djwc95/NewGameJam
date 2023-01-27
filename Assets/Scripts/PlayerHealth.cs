using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public Image dmgFlash;
    public int armor = 1;
    public int maxArmor = 1;

    Renderer render;
    Color color;

    GameObject player; //things to kill on death
    GameObject camera; //things to kill on death
    GameObject uiCanvas; //things to kill on death
    GameObject musicPlayer;

    public CameraShake cameraShake;
    public PlayerBehaviour playerBehaviour;
    public SceneSwitch sceneSwitch;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        uiCanvas = GameObject.FindGameObjectWithTag("UiCanvas");
        musicPlayer = GameObject.Find("MusicPlayer");

        dmgFlash.enabled = false;
        currentHealth = maxHealth;
        armor = maxArmor;
        render = GetComponent<Renderer>();
        color = render.material.color;

        StartCoroutine(IFrames());
    }

    void Update()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (armor >= maxArmor)
        {
            armor = maxArmor;
        }
    }

    public void OnCollisionEnter2D(Collision2D collsion)
    {
        if (collsion.gameObject.tag == "Enemy")
        {
            StartCoroutine(DamageFlash()); //player feedback
            StartCoroutine(cameraShake.Shaking()); //player feedback
            //StartCoroutine(IFrames());

            if (armor >= 1) // if we have armor, lose one until we are out
            {
                armor -= 1;
                StartCoroutine(DamageFlash());
                StartCoroutine(IFrames());
                return;
            }
            else if (armor == 0) // if no armor, take dmg
            {
                if (collsion.gameObject.tag == "Enemy")
                {
                    TakeDmg(4);
                }
            }
        }
    }

    //======================= TAKE DAMAGE CALLED FROM OTHER SCRIPTS =======================
    public void TakeDmg(int amount)
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.E)) // negate dmg while blocking
        {
            return;
        }
        currentHealth -= amount; // take dmg

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //Kill(); // kill us if we run out of health
        }
    }
    // ========================= TAKE HEALING CALLED FROM OTHER SCRIPTS ========================
    public void TakeHealth(int amount)
    {
        currentHealth += amount;
    }

    IEnumerator DamageFlash() //player feedback
    {
        dmgFlash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        dmgFlash.enabled = false;
        yield return new WaitForSeconds(0.1f);
        dmgFlash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        dmgFlash.enabled = false;
    }

    public IEnumerator IFrames() //temp invincibility on dmg taken
    {
        color.a = 0.5f;
        render.material.color = color;
        Physics2D.IgnoreLayerCollision(6, 8, true);
        yield return new WaitForSeconds(1.25f);
        Physics2D.IgnoreLayerCollision(6, 8, false);
        color.a = 1f;
        render.material.color = color;
    }

    //========================== BUFFS WE CAN BUY IN SHOP ==============================
    public void ArmorBuff(int amount)
    {
        armor += amount;
        maxArmor += amount;
    }

    public void Kill()
    {
        sceneSwitch.LoadDeathScene();
        Destroy(player);
        Destroy(camera);
        Destroy(uiCanvas);
        Destroy(musicPlayer);
    }
}
