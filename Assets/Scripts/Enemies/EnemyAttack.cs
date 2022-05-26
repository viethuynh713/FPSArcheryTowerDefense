using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float enemyAttackDmg;
    public float radius;
    public Animator anim;
    public GameObject attackPos;
    public NavMeshAgent agent;

    public float timeBetweenAtk = 1.5f;
    public float atkCountdown;
    public bool canAtk;
    public bool isAttacking;
    public float distanceToTarget;

    public void Start()
    {

        canAtk = false;
        agent = GetComponent<NavMeshAgent>();
        isAttacking = false;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (canAtk == false && atkCountdown > 0 && isAttacking == true)
        {
            atkCountdown -= Time.deltaTime;

        }
        if (atkCountdown <= 0)
        {
            isAttacking = false;
        }
        if (canAtk == true && Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) <= distanceToTarget && isAttacking == false)
        {
            AtkTheCastle();
        }
        CheckDistance();

    }
    public virtual void CheckDistance()
    {

    }
    public virtual void Attack() { }

    void AtkTheCastle()
    {
        Attack();
        canAtk = false;
        isAttacking = true;
        atkCountdown = timeBetweenAtk;
    }

}
