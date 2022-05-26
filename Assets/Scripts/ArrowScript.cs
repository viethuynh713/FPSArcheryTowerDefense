using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
