using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public float damping;
    public Vector3 offset;
    public Transform target;
    public GameObject player;

    private Vector3 velocity = Vector3.zero;

    void Start ()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //target = player.transform;
    }
    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        Vector3 newPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, damping);
    }
}
