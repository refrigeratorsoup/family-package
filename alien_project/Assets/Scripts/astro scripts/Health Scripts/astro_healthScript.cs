using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class astro_healthScript : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 3f;

    private Animator anim;
    private Rigidbody2D body;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    public gameOverScript gameOverScript;

    public leapScreen leapScreen;

    public bool leaped;

    public AudioClip newTrack;

    private audioManager theAM;

    void Start()
    {
        scoreScript.scoreValue = 0;

        health = maxHealth;

        anim = GetComponent<Animator>();

        respawnPoint = transform.position;

        leaped = false;

        theAM = FindObjectOfType<audioManager>();
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
            gameOverScript.ScoreScreen();
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
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        if (collision.tag == "leapDetector")
        {
            transform.position = new Vector3(150, 4.5f, 0);
            if (newTrack != null)
            {
                theAM.ChangeBGM(newTrack);
            }
            leaped = true;
            leapScreen.VictoryScreen();
        }
    }
}