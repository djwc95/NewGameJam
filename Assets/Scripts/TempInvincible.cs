using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempInvincible : MonoBehaviour
{
    Renderer render;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        color = render.material.color;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            StartCoroutine("GetInvincibilty");
        }
    }

    IEnumerator GetInvincibility()
    {
        Physics2D.IgnoreLayerCollision(6,8, true);
        color.a = 0.5f;
        render.material.color = color;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(6, 8, false);
        color.a = 1f;
        render.material.color = color;
    }
}
