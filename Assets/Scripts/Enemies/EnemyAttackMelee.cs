using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : EnemyAttack
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public override void CheckDistance()
    {
        
        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) <= distanceToTarget && canAtk == false && isAttacking == false)
        {
            Debug.Log("Close enough to atk");

            canAtk = true;
            
            agent.isStopped = true;

            agent.velocity = Vector3.zero;
        }
        if(Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) > distanceToTarget)
        {
            // Debug.Log("Go to Base");
            agent.isStopped = false;
        }
        
    }
    public override void Attack()
    {

        Debug.Log("Attack");
        anim.Play("MeleeEnemyAttack");

        Collider[] colliders = Physics.OverlapSphere(attackPos.transform.position, radius);

        foreach (Collider nearyby in colliders)
        {
            if (nearyby.gameObject.tag == "Castle")
            {
                // Debug.Log("Chem");
                GameManager.instance.CastleTakeDamage(enemyAttackDmg);
            }
        }
    }
}
