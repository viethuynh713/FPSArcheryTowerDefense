using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletDmg;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Castle")
        {
            GameManager.instance.CastleTakeDamage(bulletDmg);
            Destroy(gameObject);
        }
    }
}
