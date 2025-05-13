using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    private float maxHealth = 10;
    private float currenthealth;
     void Start()
    {
        currenthealth = maxHealth;
    }



     public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        HealthBarupdate();

        if (currenthealth<=0 ) {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void HealthBarupdate()
    {
        float avg = Mathf.Clamp01(currenthealth / maxHealth);

        HealthBar.transform.localScale = new Vector3(avg, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }
}
