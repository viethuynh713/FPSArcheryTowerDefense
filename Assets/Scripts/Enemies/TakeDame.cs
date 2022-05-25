using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDame : MonoBehaviour
{
    // Start is called before the first frame update
    public collisionType type;
    [SerializeField]
    private float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        
            Enemy enemy = gameObject.GetComponentInParent<Enemy>();
            
            if (other.tag == "IceArrow")
            {
                enemy.Slowdown();
                enemy.TakeDamage(damage, type == collisionType.head ? true : false);
            }
            if (other.tag == "FireArrow")
            {
                enemy.BurnEffect();
                enemy.TakeDamage(damage, type == collisionType.head ? true : false);
            }
    }
}


