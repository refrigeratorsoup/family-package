using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class astro_healthScript : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 10f;

    private Animator anim;
    private Rigidbody2D body;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    public GameOverScreen GameOverScreen;
    
    void Start()
    {
        health = maxHealth;

        anim = GetComponent<Animator>();

        respawnPoint = transform.position;
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
            GameOverScreen.Setup(0);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
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

    private void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        if (health <= 0)
        {
            GetComponent<Renderer>().enabled = false;
            anim.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fallDetector")
        {
            health = maxHealth;
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}