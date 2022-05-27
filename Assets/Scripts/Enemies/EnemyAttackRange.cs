using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : EnemyAttack
{
    public GameObject enemyBullet;

    public GameObject lookAtBase;

    public float bulletForce;

    void Start()
    {
        base.Start();
        lookAtBase = GameObject.FindGameObjectWithTag("Castle");
    }

    void Update()
    {
        base.Update();
    }
    public override void CheckDistance()
    {
        
        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) <= distanceToTarget && canAtk == false && isAttacking == false)
        {


            transform.LookAt(lookAtBase.transform);

            canAtk = true;

            agent.isStopped = true;

            agent.velocity = Vector3.zero;
        }

        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) > distanceToTarget)
        {
            // Debug.Log("Go to Base");
            agent.isStopped = false;
        }


    }
    public override void Attack()
    {
        Vector3 direction = attackPos.transform.position - transform.position;

        anim.Play("RangedEnemyAttack");

        GameObject eBullet = Instantiate(enemyBullet,attackPos.transform.position, Quaternion.identity);

        eBullet.GetComponent<Rigidbody>().AddForce(direction * bulletForce, ForceMode.Impulse);

        Destroy(eBullet, 3);


    
    }
}
