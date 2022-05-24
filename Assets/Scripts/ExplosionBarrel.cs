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
            
            Rigidbody rb = nearyby.GetComponent<Rigidbody>();
           
            if (rb != null)
            {
                
                rb.AddExplosionForce(expForce, transform.position, radius);
            }

            if (rigg != null)
            {
                
                rigg.TakeDamage(barrelExplosionDamage,false);
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
