using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float enemyAttackDmg;
    public float radius;
    private Animator anim;
    public GameObject attackPos;
    public NavMeshAgent agent;

    public float timeBetweenAtk = 1.5f;
    public float atkCountdown;
    public bool canAtk;
    public bool isAttacking;
    public float distanceToTarget;

    void Start()
    {
        
        canAtk = false;
        agent = GetComponent<NavMeshAgent>();
        isAttacking = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
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


        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) <= distanceToTarget && canAtk == false && isAttacking == false)
        {
            canAtk = true;
            // 
            agent.isStopped = true;

            agent.velocity = Vector3.zero;
        }
        if(Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) > distanceToTarget)
        {
            agent.isStopped = false;
        }
    }
    public void Attack()
    {

        anim.Play("MeleeEnemyAttack");

        Collider[] colliders = Physics.OverlapSphere(attackPos.transform.position, radius);

        foreach (Collider nearyby in colliders)
        {
            if (nearyby.gameObject.tag == "Castle")
            {
        Debug.Log("Chem");
                GameManager.instance.castleHealth -= 10;
            }
        }
    }
        void AtkTheCastle()
    {
        Attack();
        canAtk = false;
        isAttacking = true;
        atkCountdown = timeBetweenAtk;
    }

}
