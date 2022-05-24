using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBarrel : MonoBehaviour
{
    public GameObject exp;

    public int barrelExplosionDamage;

    public float expForce, radius;

    public void Knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        

        foreach (Collider nearyby in colliders)
        {
            Enemy rigg = nearyby.GetComponent<Enemy>();
            

            if (rigg != null)
            {
                
                rigg.TakeDamage(barrelExplosionDamage);
            }
        }

        Collider[] collidersDmg = Physics.OverlapSphere(transform.position, radius);
        

        foreach (Collider nearyby in collidersDmg)
        {
            Rigidbody rb = nearyby.GetComponent<Rigidbody>();
           
            if (rb != null)
            {
                
                rb.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }

    public void Explosion()
    {
        GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
        Destroy(_exp, 3);
        Knockback();
        Destroy(gameObject);
    }
}
