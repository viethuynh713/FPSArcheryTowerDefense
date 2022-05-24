using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcedArrow : MonoBehaviour
{
    public int damage;
    public float knockbackForce;
    public Enemy takeDmg;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Enemy>())
        {
            takeDmg = null;

            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                Vector3 direction = collider.transform.position - transform.position;
                direction.y = 0;
                rb.AddForce(-direction.normalized * knockbackForce, ForceMode.Impulse);

                Enemy stats = collider.GetComponent<Enemy>();
                stats.Slowdown();
                stats.TakeDamage(damage);
                
            }

            
        }

        if (collider.GetComponent<ExplosionBarrel>())
        {
            ExplosionBarrel EB = collider.GetComponent<ExplosionBarrel>();
            EB.Explosion();
        }
    }


}
