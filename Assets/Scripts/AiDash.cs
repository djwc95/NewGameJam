using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDash : MonoBehaviour
{
    public GameObject player;
    float speed;
    public float startSpeed;
    public float followRange;

    private bool isDashing;
    private bool canDash;
    public float dashSpeed;
    public float dashLength = .35f;
    public float dashRange = 5f;

    public float kbStrength = 5f;
    public float kbDelay = .75f;

    private bool isDashHandler;

    public float currentDistance;

    public SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (player == null)
        {
            return;
        }

        currentDistance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //======================== CHASE PLAYER IF THEY ARE IN RANGE, STOP OTHERWISE ====================
        if (currentDistance < dashRange)
        {
            if (!isDashHandler)
            {
                StartCoroutine(Dash());
            }
            if (isDashing)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * startSpeed * dashSpeed);
            }
        }
        else if (currentDistance < followRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, startSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            return;
        }
    }

    public void Knockback()
    {
        Debug.Log("Knockback called");
        StopAllCoroutines();
        speed = -kbStrength;
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(kbDelay);
        speed = startSpeed;
        Debug.Log("resetSpd");

    }

    public IEnumerator Dash()
    {
        isDashHandler = true;
        canDash = true;
        StartCoroutine(FlashGrey());
        yield return new WaitForSeconds(0.5f); // warning period for player
        isDashing = true;
        yield return new WaitForSeconds(dashLength); // how long enemy dashes
        canDash = false;
        isDashing = false;
        yield return new WaitForSeconds(4f); // enemy dash cooldown
        canDash = true;
        isDashHandler = false;
    }
    public IEnumerator FlashGrey() // flash to indicate dash incoming
    {
        rend.color = Color.grey;
        yield return new WaitForSeconds(.15f);
        rend.color = Color.white;
        yield return new WaitForSeconds(.15f);
        rend.color = Color.grey;
        yield return new WaitForSeconds(.15f);
        rend.color = Color.white;
    }
}