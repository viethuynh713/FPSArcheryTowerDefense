using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcedArrow : MonoBehaviour
{
    private Rigidbody rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.GetComponent<ExplosionBarrel>())
        {
            ExplosionBarrel EB = collider.GetComponent<ExplosionBarrel>();
            EB.Explosion();
        }

        
        

    }

    

}
