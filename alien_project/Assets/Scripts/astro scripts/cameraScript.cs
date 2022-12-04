using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    public astro_healthScript astroHScript;


    void Start()
    {
        damping = 0.5f;
    }

    void FixedUpdate()
    {
        Vector3 movePosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = -10;
        transform.position = pos;

        if (astroHScript.leaped == true)
        {
            transform.position = new Vector3(150, 6, -10);
            damping = 0;
        }
    }

}
