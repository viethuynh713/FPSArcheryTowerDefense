using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompArrowScript : MonoBehaviour
{
    public int damage;
    public GameObject exp;

    public float expForce, radius;

    public void Knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach( Collider nearyby in colliders)
        {
            Enemy rigg = nearyby.GetComponent<Enemy>();

            Rigidbody rb = nearyby.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(expForce, transform.position, radius);
            }
            if(rigg != null)
            {
                rigg.BurnEffect();
            }
        }


    }

    void OnTriggerEnter(Collider collider)
    {
        // if (collider.GetComponent<Enemy>())
        // {  
        //     GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
        //     Destroy(_exp, 3);
        //     Knockback();
        //     Destroy(gameObject);
        // }

        if (collider.GetComponent<ExplosionBarrel>())
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            Knockback();
            Destroy(gameObject);
            ExplosionBarrel EB = collider.GetComponent<ExplosionBarrel>();
            EB.Explosion();
        }
    }
}
