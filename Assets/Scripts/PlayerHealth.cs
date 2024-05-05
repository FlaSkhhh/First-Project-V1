using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0f)
        {
            health = 0f;
            Die();
        }
    }

    void OnTriggerEnter(Collider c)
    { 
        if (c.CompareTag("Boss"))
        {
            health = 0f;
            Die();
        }
        if (c.CompareTag("HeadCrab"))
        {
            TakeDamage(10);
        }
    }
    void Update()
    {
      Transform pos = GetComponent<Transform>();
      if (pos.position.y < -5f) 
      {
         TakeDamage(100);
         Die();
      }
    }

    public void Die()
    {
      FindObjectOfType<GameManager>().GameOver();
    }
}

