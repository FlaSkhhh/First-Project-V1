using UnityEngine;

public class BossTarget : MonoBehaviour
{
    public float health = 150f;
    public Animator animator;
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0f)
        {
            Die();
        }
    }
    public void Die()
    {
        animator.SetBool("Death", true);
    }
}
