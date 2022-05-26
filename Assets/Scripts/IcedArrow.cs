using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcedArrow : MonoBehaviour
{
    public int damage;
    public float knockbackForce;

    void OnTriggerEnter(Collider collider)
    {

        if (collider.GetComponent<ExplosionBarrel>())
        {
            ExplosionBarrel EB = collider.GetComponent<ExplosionBarrel>();
            EB.Explosion();
        }
    }


}
