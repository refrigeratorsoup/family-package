using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astro_healthScript : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 10f;

    private Animator anim;
    
    void Start()
    {
        health = maxHealth;

        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
            //GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            Debug.Log(health);

            TakeDamage(1);
        }
    }

    void Update()
    {

    }
}