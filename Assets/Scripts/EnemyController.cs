using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Player playerS;
    public int minDamage;
    public int maxDamage;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization if needed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = null;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamagePlayer()
    {
        if (playerS != null)
        {
            int damage = UnityEngine.Random.Range(minDamage, maxDamage);
            Debug.Log("Player take damage: " + damage);
            // Call playerS's method to apply damage here
        }
    }
}
