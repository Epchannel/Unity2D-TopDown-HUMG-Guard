using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]  int maxHealth;
    int currentHealth;

    public HeathBar healthBar;

    public UnityEvent OnDeath;

    public float safeTime = 1f;
    float safeTimeCooldown;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);

    }

    public void TakeDamage(int damage)
    {
        if (safeTimeCooldown <= 0)
        {
            currentHealth -= damage;
            
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnDeath.Invoke();
            }

            safeTimeCooldown = safeTime;
            healthBar.UpdateBar(currentHealth, maxHealth);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }




    void Update()
    {
        safeTimeCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
}
