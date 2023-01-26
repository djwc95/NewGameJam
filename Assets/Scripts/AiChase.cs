using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float startSpeed = 2.5f;
    public float distanceBetween;
    bool facingRight = false;

    public Rigidbody2D rb;
    public float kbStrength = 5f;
    public float kbDelay = .75f;

    float currentDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
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
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //======================== CHASE PLAYER IF THEY ARE IN RANGE, STOP OTHERWISE ====================
        if(currentDistance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        if(direction.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void Knockback()
    {
        //StopAllCoroutines();
        speed = -kbStrength;
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(kbDelay);
        speed = startSpeed;
    }
}
