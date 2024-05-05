using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public float lookRadius = 25f;
    Transform target;
    public Animator animator;
    private float nextFire = 0f;
    private float fireRate = 1f;
    public GameObject spawn;
    public GameObject FireBall;
    public AudioManager sound;
    public GameManager gm;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            animator.SetFloat("Speed", 2);
            agent.SetDestination(target.position);
            if (distance <= 10f)
            {
                agent.speed = 0f;
                animator.SetFloat("Speed", 0);
                FaceTarget();
                if (Time.time >= nextFire)
                {
                   agent.speed = 0f;
                   nextFire = Time.time + 1 / fireRate;
                   animator.SetTrigger("FireBall");
                }
            }
            else
            {   
                agent.speed = 3.5f;
                animator.SetFloat("Speed", 2);
                agent.SetDestination(target.position);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
            animator.SetTrigger("Idle");
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Attack()
    {   sound.Play("FireBall");
        GameObject FBall = Instantiate(FireBall, spawn.transform.position, spawn.transform.rotation);
        Rigidbody rb = FBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce((Vector3.forward * 8f + Vector3.up * 1.3f), ForceMode.Impulse);
    }

    public void Victory()
    {
        gm.Victory();
    }

}
