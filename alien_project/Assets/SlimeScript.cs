using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public float slimeHealth;
    public float slimeMaxHealth = 10f;

    // Start is called before the first frame update
    void Start()
    {
        slimeHealth = slimeMaxHealth;
    }

    void GetShot()
    {
        slimeHealth -= 1;
        if (slimeHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            GetShot();
            Destroy(col.gameObject);
        }
    }

}
