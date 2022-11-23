using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMove : MonoBehaviour
{
    public int maxSpeed;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        maxSpeed = 1;

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontall();
    }

    void MoveHorizontall()
    {
        transform.position = new Vector3(transform.position.y, startPosition.x + Mathf.Sin(Time.time * maxSpeed), transform.position.z);

        if (transform.position.x > 1.0f)
        {
            transform.position = new Vector3(transform.position.y, transform.position.x, transform.position.z);
        }
        else if (transform.position.x < -1.0f)
        {
            transform.position = new Vector3(transform.position.y, transform.position.x, transform.position.z);
        }
    }
}