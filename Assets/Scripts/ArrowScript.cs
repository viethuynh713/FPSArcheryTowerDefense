using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArrowScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<ExplosionBarrel>())
        {
            ExplosionBarrel EB = collider.GetComponent<ExplosionBarrel>();
            EB.Explosion();
        }

    }
}
