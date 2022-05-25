using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float enemyAttackDmg;
    public float radius;
    private Animator anim;
    public GameObject attackPos;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.Play("MeleeEnemyAttack");

        Collider[] colliders = Physics.OverlapSphere(attackPos.transform.position, radius);
        
        foreach (Collider nearyby in colliders)
        {
            if(nearyby.gameObject.tag == "Castle")
            {
                GameManager.instance.castleHealth -= 10;
            }
        }
    }

}
