using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage;
    

    void OnTriggerEnter(Collider collider)
    {
        // if (collider.GetComponent<Enemy>())
        // {
        //     Enemy stats = collider.GetComponent<Enemy>();
        //     stats.TakeDamage(damage);
        // }
        
    }


}
