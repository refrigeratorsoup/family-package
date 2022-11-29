using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runConstant : MonoBehaviour
{
    private bool swap = true;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    void Update()
    {
        if (swap == true)
            moveRight();

        if (swap == false)
            moveLeft();

        if (transform.position.x >= 10)
        {
            swap = false;
            sprite.flipX = false;
        }

        if (transform.position.x <= -10)
        {
            swap = true;
            sprite.flipX = true;
        }
    }

    private void moveRight()
    {
        transform.Translate(5 * Time.deltaTime,0 ,0);
    }

    private void moveLeft()
    {
        transform.Translate(-5 * Time.deltaTime, 0, 0);
    }
}
