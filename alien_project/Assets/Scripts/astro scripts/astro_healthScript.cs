using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astro_healthScript : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] float health, maxHealth = 20f;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collising");

        if (col.gameObject.CompareTag("enemy"))
        {
            Debug.Log("health");

            TakeDamage(1);
        }
    }

=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
>>>>>>> Stashed changes
    void Update()
    {
        
    }
}
