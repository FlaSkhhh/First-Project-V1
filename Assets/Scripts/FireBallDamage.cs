using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBallDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    private float damage = 20f;
    public void OnTriggerEnter(Collider collider) 
    { 
    if (collider != null)
        {
            GameObject ex = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(ex, 2f);    

            if (collider.CompareTag("Player"))
            {
                PlayerHealth hp = collider.GetComponent<PlayerHealth>();
                if (collider.GetComponent<PlayerHealth>().enabled == true)
                {
                    if (hp != null)
                    {
                        Destroy(gameObject);
                        hp.TakeDamage(damage);
                    }
                }
            }
            if (collider.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
        }
    else
     {
     Destroy(gameObject,3f);
     }
    } 
}
