using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exp;
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
                Destroy(other);
            }
            if (other.tag == "FireArrow")
            {
                GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
                enemy.BurnEffect();
                enemy.TakeDamage(damage, type == collisionType.head ? true : false);
                Destroy(other);
                Destroy(_exp, 3);
            }
            if (other.tag == "NormalArrow")
            {
                enemy.TakeDamage(damage, type == collisionType.head ? true : false);
                Destroy(other);
                
            }


    }
}


