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
            transform.localScale = new Vector3(0.1f, 0.1f, 0);
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
        if (Input.GetKey(KeyCode.R))
        {
            gameObject.SetActive(true);
            health = maxHealth;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}