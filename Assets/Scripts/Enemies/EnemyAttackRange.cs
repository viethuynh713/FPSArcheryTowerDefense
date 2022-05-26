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

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public override void CheckDistance()
    {
        Debug.Log("CheckDistance");
        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().targetWp.position) <= distanceToTarget && canAtk == false && isAttacking == false)
        {
            canAtk = true;

            agent.isStopped = true;

            agent.velocity = Vector3.zero;
        }
        

    }
    public override void Attack()
    {

        Debug.Log("Ranged Attack");
        anim.Play("RangedEnemyAttack");

        GameObject eBullet = Instantiate(enemyBullet,attackPos.transform.position, Quaternion.identity);

        eBullet.GetComponent<Rigidbody>().AddForce(-attackPos.transform.position * bulletForce, ForceMode.Impulse);

        


        //Collider[] colliders = Physics.OverlapSphere(attackPos.transform.position, radius);

        //foreach (Collider nearyby in colliders)
        //{
        //    if (nearyby.gameObject.tag == "Castle")
        //    {
        //        Debug.Log("Chem");
        //        GameManager.instance.castleHealth -= 10;
        //    }
        //}
    }
}
