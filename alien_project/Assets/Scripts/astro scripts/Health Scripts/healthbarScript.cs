using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbarScript : MonoBehaviour
{
    [SerializeField] private astro_healthScript playerHealth;

    [SerializeField] private Image HealthbarTotal;
    [SerializeField] private Image HealthbarCurrent;

    void Start()
    {
        HealthbarTotal.fillAmount = playerHealth.health / 10;
    }

    void Update()
    {
        HealthbarCurrent.fillAmount = playerHealth.health / 10;
    }
}
