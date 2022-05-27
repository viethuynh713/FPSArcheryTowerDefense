using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : EnemyAttack
{
    public GameObject enemyBullet;

    public float bulletForce;

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
    }
    public override void CheckDistance()
    {
        
        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) <= distanceToTarget && canAtk == false && isAttacking == false)
        {
            canAtk = true;

            agent.isStopped = true;

            agent.velocity = Vector3.zero;
        }
        

    }
    public override void Attack()
    {

        anim.Play("RangedEnemyAttack");

        GameObject eBullet = Instantiate(enemyBullet,attackPos.transform.position, Quaternion.identity);

        eBullet.GetComponent<Rigidbody>().AddForce(-attackPos.transform.position * bulletForce, ForceMode.Impulse);

        Destroy(eBullet, 3);
    
    }
}
