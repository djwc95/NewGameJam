using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    //
    public float moveSpeed;
    public Rigidbody2D rb;
    //
    Vector2 moveInput;
    bool facingRight = true;
    //
    public float dashLength = 1f;
    public float dashSpeed = 5f;
    float activeMoveSpeed;
    public float dashCooldown;
    //
    public float dashCounter;
    public float dashCoolCounter;
    //
    Renderer render;
    Color color;
    public Image dashIcon;
    Animator anim;

    // ==================== SETTING EVERYTHING UP ==========================
    void Start()
    {
        moveSpeed = 5f;
        activeMoveSpeed = moveSpeed;
        render = GetComponent<Renderer>();
        color = render.material.color;
        dashIcon.enabled = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ===================== MOVEMENT STUFF ======================
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        rb.velocity = moveInput * activeMoveSpeed;

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.E)) //Lock mvmt while using shield
        {
            activeMoveSpeed = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.E)) //Lock mvmt while using shield
        {
            activeMoveSpeed = moveSpeed;
        }

        // ====================== DASH MECHANIC (SPACE TO DASH) =====================

        while (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.E))
        {
            return;
        }
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            dashIcon.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //==================== SETS MOVE SPEED TO DASH SPEED FOR X SECONDS ==========
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

                //======================== GAIN TEMP INVINCIBILITY ====================
                color.a = 0.5f;
                render.material.color = color;
                Physics2D.IgnoreLayerCollision(6, 8, true);
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                //================== LOSE INVINCIBILITY =========================
                Physics2D.IgnoreLayerCollision(6, 8, false);
                color.a = 1f;
                render.material.color = color;
            }
        }
        //================= HOW LONG TILL WE CAN DASH AGAIN =====================
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            dashIcon.enabled = false;
        }
    }

    void FixedUpdate()
    {
        // ================== FLIPPING SPRITE DIRECTION BASED ON INPUT =============================
        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }
        if (moveInput.x < 0 && facingRight)
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

    //========================== BUFFS WE CAN BUY IN SHOP ==============================
    public void DashBuff(float amount)
    {
        dashCooldown -= amount;
    }

    public void SpeedBuff(int amount)
    {
        moveSpeed += amount;
    }
}
